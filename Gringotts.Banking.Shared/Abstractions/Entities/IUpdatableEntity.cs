namespace Gringotts.Banking.Shared.Abstractions.Entities;

public interface IUpdatableEntity : IEntity
{
    DateTime? ModifiedOnUtc { get; }
}