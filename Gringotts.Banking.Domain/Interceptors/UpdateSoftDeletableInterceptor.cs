using Gringotts.Banking.Shared.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Gringotts.Banking.Domain.Interceptors;

public sealed class UpdateSoftDeletableInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        if (eventData.Context is not null)
        {
            UpdateSoftDeletableEntities(eventData.Context);
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private static void UpdateSoftDeletableEntities(DbContext context)
    {
        DateTime utcNow = DateTime.UtcNow;

        var entities = context.ChangeTracker.Entries<ISoftDeletableEntity>().ToList();

        foreach (EntityEntry<ISoftDeletableEntity> entry in entities)
        {
            if (entry.State == EntityState.Deleted)
            {
                SetCurrentPropertyValue(
                    entry, nameof(ISoftDeletableEntity.DeletedOnUtc), utcNow);

                SetCurrentPropertyValue(
                    entry, nameof(ISoftDeletableEntity.IsDeleted), true);

                entry.State = EntityState.Modified;

                UpdateDeletedEntityEntryReferencesToUnchanged(entry);
            }
        }

        static void SetCurrentPropertyValue(
            EntityEntry entry,
            string propertyName,
            object value) =>
            entry.Property(propertyName).CurrentValue = value;

        static void UpdateDeletedEntityEntryReferencesToUnchanged(EntityEntry entityEntry)
        {
            if (!entityEntry.References.Any())
            {
                return;
            }

            foreach (ReferenceEntry referenceEntry in entityEntry.References.Where(r => r.TargetEntry?.State == EntityState.Deleted))
            {
                referenceEntry.TargetEntry!.State = EntityState.Unchanged;

                UpdateDeletedEntityEntryReferencesToUnchanged(referenceEntry.TargetEntry);
            }
        }
    }
}
