namespace Gringotts.Banking.Domain.Entities;

using Gringotts.Banking.Domain.Events;
using Gringotts.Banking.Shared;
using Gringotts.Banking.Shared.Abstractions.Entities;
using System.Security.Cryptography;
using System.Text;

public class User : Entity<Guid>, IAuditableEntity
{

    /// <summary>
    /// FirstName
    /// </summary>
    public required string FirstName { get; set; }

    /// <summary>
    /// LastName
    /// </summary>
    public required string LastName { get; set; }

    /// <summary>
    /// Email
    /// </summary>
    public required string Email { get; set; }

    /// <summary>
    /// PhoneNumber
    /// </summary>
    public required string PhoneNumber { get; set; }

    /// <summary>
    /// CitizenshipNumber
    /// </summary>
    public required long CitizenshipNumber { get; set; }

    /// <summary>
    /// Password Hash
    /// </summary>
    public required string PasswordHash { get; init; }

    const string ConstantSalt = "xi07cevs01q4#";
    /// <summary>
    /// User creation time
    /// </summary>
    public DateTime CreatedOnUtc { get; }

    /// <summary>
    /// User modified time
    /// </summary>
    public DateTime? ModifiedOnUtc { get; }


    /// <summary>
    /// CreateUser
    /// </summary>
    public static User CreateUser(
        string email,
        string firstName,
        string lastName,
        long citizenshipNumber,
        string phoneNumber,
        string password)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            CitizenshipNumber = citizenshipNumber,
            PhoneNumber = phoneNumber,
            PasswordHash = Convert.ToBase64String(SHA256.Create().ComputeHash(Encoding.Unicode.GetBytes(password)))
        };

        user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));

        return user;
    }

}
