using Gringotts.Banking.Application.Contracts.Transactions.Dto;
using Gringotts.Banking.Shared.Enums;

namespace Gringotts.Banking.Application.Contracts.Accounts.Dto;

public class AccountDto
{
    public Guid Id { get; init; }

    public Guid UserId { get; init; }

    public Currency Currency { get; init; }

    public decimal Total { get; init; }

    public decimal Locked { get; init; }

    public decimal Available { get; init; }

    public DateTime CreatedOnUtc { get; init; }

    public DateTime? ModifiedOnUtc { get; init; }

    public List<TransactionDto?> Transactions { get; set; }
}