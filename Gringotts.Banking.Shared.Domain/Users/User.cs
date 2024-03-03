namespace Papara.Investment.Shared.Domain.Users;

using Papara.Investment.Framework.Ddd;
using Papara.Investment.Framework.Ddd.Abstractions.Entities;
using Papara.Investment.Shared.Domain.UserDocuments;
using Papara.Investment.Shared.Domain.UserServiceProviders;
using Papara.Investment.Shared.Domain.UserSettings;
using Papara.Investment.Shared.Domain.UserSurveys;

/// <summary>
/// User
/// </summary>
public class User : Entity<Guid>, IAuditableEntity
{
    /// <summary>
    /// ClientNumber
    /// </summary>
    public required long ClientNumber { get; init; }

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
    /// HashedCitizenshipNumber
    /// </summary>
    public required string HashedCitizenshipNumber { get; set; }

    /// <summary>
    /// CreatedOnUtc
    /// </summary>
    public DateTime CreatedOnUtc { get; }

    /// <summary>
    /// ModifiedOnUtc
    /// </summary>
    public DateTime? ModifiedOnUtc { get; }

    /// <summary>
    /// Setting
    /// </summary>
    public UserSetting? Setting { get; set; }

    /// <summary>
    /// ServiceProviders
    /// </summary>
    public List<UserServiceProvider> ServiceProviders { get; set; } = new();

    /// <summary>
    /// AccountServiceProviders
    /// </summary>
    public List<UserAccountServiceProvider> AccountServiceProviders { get; set; } = new();

    /// <summary>
    /// Documents
    /// </summary>
    public List<UserDocument> Documents { get; set; } = new();

    /// <summary>
    /// SurveyResults
    /// </summary>
    public List<UserSurveyResult> SurveyResults { get; set; } = new();

    /// <remarks>
    /// Required by EF Core.
    /// </remarks>
    private User() { }

    /// <summary>
    /// CreateUser
    /// </summary>
    public static User CreateUser(
        Guid id, 
        string email, 
        string firstName, 
        string lastName, 
        long clientNumber, 
        long citizenshipNumber, 
        string hashedCitizenshipNumber,
        string phoneNumber)
    {
        var user = new User
        {
            Id = id,
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            ClientNumber = clientNumber,
            CitizenshipNumber = citizenshipNumber,
            HashedCitizenshipNumber = hashedCitizenshipNumber,
            PhoneNumber = phoneNumber
        };

        user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));

        return user;
    }
}