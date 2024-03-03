namespace Gringotts.Banking.Domain.EntitiesConfigurations;

using Gringotts.Banking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> b)
    {
        b.ToTable("Accounts");

        b.Property(p => p.Total).HasPrecision(18, 8);

        b.Property(p => p.Locked).HasPrecision(18, 8);

        b.HasIndex(p => p.UserId);

        b.HasIndex(p => p.Currency);
    }
}