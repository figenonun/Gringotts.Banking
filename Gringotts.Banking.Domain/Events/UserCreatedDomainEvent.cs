namespace Gringotts.Banking.Domain.Events;
using Gringotts.Banking.Shared;

public sealed record UserCreatedDomainEvent(Guid UserId) :
    ISyncDomainEvent, IAsyncDomainEvent;