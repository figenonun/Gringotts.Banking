namespace Gringotts.Banking.Shared;

public abstract class Entity
{
    private readonly List<IDomainEvent> _domainEvents = new();

    public IReadOnlyList<IDomainEvent> GetDomainEvents()
    {
        return _domainEvents.ToList();
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}

public abstract class Entity<T> : Entity
{
    protected Entity(T id)
    {
        Id = id;
    }

    protected Entity()
    {
    }

    public required T Id { get; init; }
}