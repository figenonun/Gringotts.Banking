namespace Gringotts.Banking.Shared.Abstractions.Entities;


public interface ISoftDeletableEntity : IEntity
{
    /// <summary>
    /// Gets the date and time in UTC format the entity was deleted on.
    /// </summary>
    DateTime? DeletedOnUtc { get; }

    /// <summary>
    /// Gets a value indicating whether the entity has been deleted.
    /// </summary>
    bool IsDeleted { get; }
}