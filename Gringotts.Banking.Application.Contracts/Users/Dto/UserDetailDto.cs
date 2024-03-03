namespace Gringotts.Banking.Application.Contracts.Users.Dto;

/// <summary>
/// User Details Response Dto
/// </summary>
public class UserDetailDto
{
    /// <summary>
    /// Papara Account Number
    /// </summary>
    public long PaparaAccountNumber { get; set; }

    /// <summary>
    /// First Name
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Last Name
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Email
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Phone number
    /// </summary>
    public string PhoneNumber { get; set; }
}
