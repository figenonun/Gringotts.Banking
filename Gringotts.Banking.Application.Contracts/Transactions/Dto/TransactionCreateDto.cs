using Gringotts.Banking.Shared.Enums;

namespace Gringotts.Banking.Application.Contracts.Transactions.Dto;

public class TransactionCreateDto
{
    public required Guid UserId { get; init; }

    public required Guid AccountId { get; init; }

    public required TransactionType TransactionType { get; init; }

    public required Currency Currency { get; init; }

    public required decimal Amount { get; init; }

    public required DateTime TransactionDate { get; init; }

}
