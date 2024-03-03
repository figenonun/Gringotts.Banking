
using Gringotts.Banking.Shared.Enums;

namespace Gringotts.Banking.Application.Contracts.Transactions.Dto;

public class TransactionDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }

    public Guid AccountId { get; set; }

    public TransactionType TransactionType { get; set; }

    public Currency Currency { get; set; }

    public decimal Amount { get; set; }

    public DateTime TransactionDate { get; set; }

}
