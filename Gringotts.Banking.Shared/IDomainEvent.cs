namespace Gringotts.Banking.Shared;
using MediatR;
public interface IDomainEvent : INotification
{
}

public interface ISyncDomainEvent : IDomainEvent
{
}

public interface IAsyncDomainEvent : IDomainEvent
{
}