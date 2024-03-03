namespace Gringotts.Banking.Shared.Abstractions.Entities;

public interface ICreatableEntity : IEntity
{
    DateTime CreatedOnUtc { get; }
}
