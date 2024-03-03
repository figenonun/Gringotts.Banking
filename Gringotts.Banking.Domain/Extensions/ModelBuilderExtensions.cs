namespace Gringotts.Banking.Domain.Extensions;

using Gringotts.Banking.Shared.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;

public static class ModelBuilderExtensions
{
    public static void ApplyAuditableEntityConfigurations(this ModelBuilder modelBuilder)
    {
        foreach (var t in modelBuilder.Model.GetEntityTypes())
        {           
            if (typeof(ICreatableEntity).IsAssignableFrom(t.ClrType))
            {
                modelBuilder.Entity(t.ClrType).Property(nameof(IAuditableEntity.CreatedOnUtc)).IsRequired();

                modelBuilder.Entity(t.ClrType).HasIndex(nameof(IAuditableEntity.CreatedOnUtc));
            }

            if (typeof(IUpdatableEntity).IsAssignableFrom(t.ClrType))
            {
                modelBuilder.Entity(t.ClrType).Property(nameof(IAuditableEntity.ModifiedOnUtc));

                modelBuilder.Entity(t.ClrType).HasIndex(nameof(IAuditableEntity.ModifiedOnUtc));
            }
        }
    }

    public static void ApplySoftDeletableEntityConfigurations(this ModelBuilder modelBuilder)
    {
        foreach (var t in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(ISoftDeletableEntity).IsAssignableFrom(t.ClrType))
            {
                modelBuilder.Entity(t.ClrType).Property(nameof(ISoftDeletableEntity.DeletedOnUtc)).IsRequired(false);

                modelBuilder.Entity(t.ClrType).HasIndex(nameof(ISoftDeletableEntity.DeletedOnUtc));

                modelBuilder.Entity(t.ClrType).Property(nameof(ISoftDeletableEntity.IsDeleted)).IsRequired();

                modelBuilder.Entity(t.ClrType).HasIndex(nameof(ISoftDeletableEntity.IsDeleted));
            }
        }
    }
}
