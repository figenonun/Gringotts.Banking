using Gringotts.Banking.Shared.Abstractions;

namespace Gringotts.Banking.Domain.Errors;

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
        "User.NotFound",
        "The user with the specified identifier was not found");

    /// <summary>
    /// UserIdInvalid
    /// </summary>
    public static Error UserIdInvalid => new(
        1204,
        "User.UserIdInvalid",
        "User Id is empty or invalid"); 
    
    public static Error FirstNameInvalid => new(
        1208,
        "User.FirstName",
        "User FirstName is empty or invalid");
    public static Error LastNameInvalid => new(
        1209,
        "User.LastName",
        "User LastName is empty or invalid");   
    
    public static Error PhoneNumberInvalid => new(
        1210,
        "User.PhoneNumber",
        "User PhoneNumber is empty or invalid");  
    
    public static Error CitizenshipNumberInvalid => new(
        1211,
        "User.CitizenshipNumber",
        "User CitizenshipNumber is empty or invalid");
    
    public static Error PasswordInvalid => new(
        1211,
        "User.PasswordInvalid",
        "User PasswordInvalid is empty or invalid");
}
