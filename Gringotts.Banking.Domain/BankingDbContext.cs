namespace Gringotts.Banking.Domain;

using Gringotts.Banking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

/// <summary>
/// SharedDbContext
/// </summary>
public class BankingDbContext : BaseDbContext<BankingDbContext>
{
    /// <summary>
    /// Users
    /// </summary>
    public DbSet<User> Users => Set<User>();

    /// <summary>
    /// Accounts
    /// </summary>
    public DbSet<Account> Accounts => Set<Account>();

    /// <summary>
    /// Transactions
    /// </summary>
    public DbSet<Transaction> Transactions => Set<Transaction>();

    /// <summary>
    /// SharedDbContext
    /// </summary>
    public BankingDbContext(DbContextOptions<BankingDbContext> options) : base(options)
    {
    }

    /// <summary>
    /// OnModelCreating
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Account>().Property(e => e.Total).HasPrecision(18, 2);
        modelBuilder.Entity<Account>().Property(e => e.Locked).HasPrecision(18, 2);
        modelBuilder.Entity<Transaction>().Property(e => e.Amount).HasPrecision(18, 2);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
