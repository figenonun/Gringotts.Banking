namespace Gringotts.Banking.Application.Contracts.Users.Dto;

public class UserCreateRequest
{
    public required string FirstName { get; init; }

    public required string LastName { get; init; }

    public required string Email { get; init; }

    public required string PhoneNumber { get; init; }

    public required long CitizenshipNumber { get; set; }

    public required string Password { get; set; }
}