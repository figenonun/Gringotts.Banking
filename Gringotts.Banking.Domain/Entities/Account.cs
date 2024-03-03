namespace Gringotts.Banking.Domain.Entities;

using Gringotts.Banking.Shared.Abstractions.Entities;
using Gringotts.Banking.Shared.Enums;
using Gringotts.Banking.Shared.Abstractions;
using Gringotts.Banking.Domain.Errors;
using System.Diagnostics.CodeAnalysis;
using Gringotts.Banking.Shared;

public class Account : Entity<Guid>, IAuditableEntity
{

    public required Guid UserId { get; init; }

    public required Currency Currency { get; init; }

    public decimal Total { get; private set; }

    public decimal Locked { get; private set; }

    public decimal Available => Total - Locked;

    public DateTime CreatedOnUtc { get; }

    public DateTime? ModifiedOnUtc { get; }

    private List<Transaction> _transactions = new();
    public IReadOnlyList<Transaction> Transactions => _transactions;

    /// <remarks>
    /// Required by EF Core.
    /// </remarks>
    private Account() { }

    [SetsRequiredMembers]
    public Account(Guid userId, Currency currency)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        Currency = currency;
    }

    public Result Deposit(TransactionType transactionType, decimal amount, DateTime transactionDate)
    {
        if (amount <= 0)
        {
            return AccountErrors.AmountMustBePositive;
        }

        Total += amount;


        var transaction = new Transaction(transactionType, UserId, Id, Currency, amount, transactionDate);

        _transactions.Add(transaction);

        return Result.Success();
    }

    public Result CanWithdraw(decimal amount)
    {
        if (amount <= 0)
        {
            return AccountErrors.AmountMustBePositive;
        }

        return Available >= amount ?
            Result.Success() :
            AccountErrors.InsufficientBalance;
    }

    public Result Withdraw(TransactionType transactionType, decimal amount, DateTime transactionDate)
    {
        if (amount <= 0)
        {
            return AccountErrors.AmountMustBePositive;
        }

        var canWithdrawResult = CanWithdraw(amount);

        if (canWithdrawResult.IsSuccess)
        {
            Total -= amount;

            var transaction = new Transaction(transactionType, UserId, Id, Currency, amount * -1, transactionDate);

            _transactions.Add(transaction);

            return Result.Success();
        }

        return canWithdrawResult.Error;
    }
    public Result LockBalance(decimal amount)
    {
        if (amount <= 0)
        {
            return AccountErrors.AmountMustBePositive;
        }

        var canWithdrawBalanceResult = CanWithdraw(amount);

        if (canWithdrawBalanceResult.IsSuccess)
        {
            Locked += amount;
        }

        return canWithdrawBalanceResult;
    }
    public Result CanReleaseLockedBalance(decimal amount)
    {
        if (amount <= 0)
        {
            return AccountErrors.AmountMustBePositive;
        }

        return Locked >= amount ?
            Result.Success() :
            AccountErrors.InsufficientBalance;
    }

    public Result ReleaseLockedBalance(decimal amount)
    {
        if (amount <= 0)
        {
            return AccountErrors.AmountMustBePositive;
        }

        var canReleaseBalanceResult = CanReleaseLockedBalance(amount);

        if (canReleaseBalanceResult.IsSuccess)
        {
            Locked -= amount;

            return Result.Success();
        }

        return canReleaseBalanceResult.Error;
    }
}
