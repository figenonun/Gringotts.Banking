namespace Gringotts.Banking.Domain.Events;
using MediatR;

public class UserCreatedDomainEventHandler : INotificationHandler<UserCreatedDomainEvent>
{
    public Task Handle(UserCreatedDomainEvent notification, CancellationToken cancellationToken)
    {

        return Task.CompletedTask;
    }
}