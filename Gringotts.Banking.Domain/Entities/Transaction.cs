using Gringotts.Banking.Shared.Abstractions.Entities;
using Gringotts.Banking.Shared.Enums;
using System.Diagnostics.CodeAnalysis;

namespace Gringotts.Banking.Domain.Entities;

public class Transaction : ICreatableEntity
{
    public required Guid Id { get; init; }

    public required Guid UserId { get; init; }

    public required Guid AccountId { get; init; }

    public required TransactionType TransactionType { get; init; }

    public required Currency Currency { get; init; }

    public required decimal Amount { get; init; }

    public required DateTime TransactionDate { get; init; }

    public DateTime CreatedOnUtc { get; }

    /// <remarks>
    /// Required by EF Core.
    /// </remarks>
    private Transaction() { }

    [SetsRequiredMembers]
    internal Transaction(
        TransactionType transactionType,
        Guid userId,
        Guid accountId,
        Currency currency,
        decimal amount,
        DateTime transactionDate)
    {
        Id = Guid.NewGuid();
        TransactionType = transactionType;
        AccountId = accountId;
        UserId = userId;
        Currency = currency;
        Amount = amount;
        TransactionDate = transactionDate;
    }
}
