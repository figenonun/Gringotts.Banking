namespace Gringotts.Banking.Shared;
using MediatR;
public abstract class SyncEventHandler<T> : INotificationHandler<T> where T : ISyncDomainEvent
{
    public abstract Task Handle(T notification, CancellationToken cancellationToken);
}