namespace Papara.Investment.Shared.Domain.Users;

using Papara.Investment.Framework.Ddd.Abstractions;

/// <summary>
/// UserErrors
/// </summary>
public static class UserErrors
{
    /// <summary>
    /// NotFound
    /// </summary>
    public static Error NotFound = new(
        1204,
        "Shared.User.NotFound",
        "The user with the specified identifier was not found");

    /// <summary>
    /// UserIdInvalid
    /// </summary>
    public static Error UserIdInvalid => new(
        1204,
        "Shared.User.UserIdInvalid",
        "User Id is empty or invalid");
}