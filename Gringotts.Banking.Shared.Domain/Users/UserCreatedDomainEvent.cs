namespace Papara.Investment.Shared.Domain.Users;

using Papara.Investment.Framework.Ddd;

public sealed record UserCreatedDomainEvent(Guid UserId) : 
    ISyncDomainEvent, IAsyncDomainEvent;