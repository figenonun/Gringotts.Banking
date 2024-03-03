using Gringotts.Banking.Shared.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;


namespace Gringotts.Banking.Domain.Interceptors;

public sealed class UpdateAuditableInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        if (eventData.Context is not null)
        {
            UpdateAuditableEntities(eventData.Context);
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private static void UpdateAuditableEntities(DbContext context)
    {
        DateTime utcNow = DateTime.UtcNow;

        var entities = context.ChangeTracker.Entries<IEntity>().ToList();

        foreach (var entry in entities)
        {
            if (entry.Entity is ICreatableEntity && entry.State == EntityState.Added)
            {
                SetCurrentPropertyValue(
                    entry, nameof(ICreatableEntity.CreatedOnUtc), utcNow);
            }

            if (entry.Entity is IUpdatableEntity && entry.State == EntityState.Modified)
            {
                SetCurrentPropertyValue(
                    entry, nameof(IUpdatableEntity.ModifiedOnUtc), utcNow);
            }
        }

        static void SetCurrentPropertyValue(
            EntityEntry entry,
            string propertyName,
            object value) =>
            entry.Property(propertyName).CurrentValue = value;
    }
}
