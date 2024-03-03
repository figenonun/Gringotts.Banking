namespace Gringotts.Banking.Application.Contracts.Users.Dto;

public class UserDto
{
    public Guid Id { get; init; }

    public string FirstName { get; init; }

    public string LastName { get; init; }

    public string Email { get; init; }

    public string PhoneNumber { get; init; }

    public long CitizenshipNumber { get; set; }
}
