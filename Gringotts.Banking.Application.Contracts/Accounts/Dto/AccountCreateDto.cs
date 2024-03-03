using Gringotts.Banking.Shared.Enums;

namespace Gringotts.Banking.Application.Contracts.Accounts.Dto;

public class AccountCreateDto
{
    public required Guid UserId { get; init; }

    public required Currency Currency { get; init; }
}