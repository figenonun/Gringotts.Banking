namespace Gringotts.Banking.Domain;

using Gringotts.Banking.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Gringotts.Banking.Domain.Extensions;

public abstract class BaseDbContext<TDbContext> : Microsoft.EntityFrameworkCore.DbContext
    where TDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public BaseDbContext(DbContextOptions<TDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyAuditableEntityConfigurations();

        modelBuilder.ApplySoftDeletableEntityConfigurations();

        base.OnModelCreating(modelBuilder);
    }


    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.ApplyUtcDateTimeConverter();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {

        var result = await base.SaveChangesAsync(cancellationToken);

        return result;
    }

    private async Task PublishDomainEventsAsync()
    {
        var mediator = this.GetService<IMediator>();

        var domainEvents = ChangeTracker
            .Entries<Entity>()
            .Select(entry => entry.Entity)
            .SelectMany(entity =>
            {
                var domainEvents = entity.GetDomainEvents();

                entity.ClearDomainEvents();

                return domainEvents;
            })
            .ToList();

        foreach (var domainEvent in domainEvents)
        {
            if (domainEvent is ISyncDomainEvent syncEvent)
            {
            }
        }
    }

    private static readonly JsonSerializerSettings JsonSerializerSettings = new()
    {
        TypeNameHandling = TypeNameHandling.All
    };
}
