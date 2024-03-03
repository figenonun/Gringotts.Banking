namespace Gringotts.Banking.Domain.EntitiesConfigurations;

using Gringotts.Banking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> b)
    {
        b.ToTable("Transactions");

        b.Property(t => t.Id).ValueGeneratedNever();

        b.Property(p => p.Amount).HasPrecision(18, 8);

        b.HasIndex(p => p.TransactionType);

        b.HasIndex(p => p.UserId);

        b.HasIndex(p => p.AccountId);

        b.HasIndex(p => p.Currency);

        b.HasIndex(p => p.TransactionDate);

        b.HasOne<Account>()
         .WithMany(p => p.Transactions)
         .HasForeignKey(f => f.AccountId)
         .OnDelete(DeleteBehavior.Restrict);
    }
}