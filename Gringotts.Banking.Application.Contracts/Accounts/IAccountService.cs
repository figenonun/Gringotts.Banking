using Gringotts.Banking.Application.Contracts.Accounts.Dto;
using Gringotts.Banking.Shared.Abstractions;
using Gringotts.Banking.Shared.Enums;

namespace Gringotts.Banking.Application.Contracts.Accounts;

public interface IAccountService
{
    Task<Result<AccountDto>> CreateAsync(AccountCreateDto accountCreateDto, CancellationToken cancellationToken);

    Task<Result<AccountDto>> GetAsync(Guid id, CancellationToken cancellationToken);

    Task<Result<List<AccountDto>>> GetAccountsByUserIdAsync(Guid userId, CancellationToken cancellationToken);

    Task<Result> DepositAsync(Guid accountId, decimal amount, CancellationToken cancellationToken);

    Task<Result> CanWithdrawAsync(Guid accountId, decimal amount, CancellationToken cancellationToken);

    Task<Result> WithdrawAsync(Guid accountId, decimal amount, CancellationToken cancellationToken);

    Task<Result> LockBalanceAsync(Guid accountId, decimal amount, CancellationToken cancellationToken);

    Task<Result> CanReleaseLockedBalanceAsync(Guid accountId, decimal amount, CancellationToken cancellationToken);

    Task<Result> ReleaseLockedBalanceAsync(Guid accountId, decimal amount, CancellationToken cancellationToken);

    Task<Result<AccountDto>> GetAccountTransactionById(Guid transactionId, Guid accountId, CancellationToken cancellationToken);

    Task<Result<AccountDto>> GetAccountTransactions(Guid accountId, int page, int limit, CancellationToken cancellationToken);

    Task<Result<List<AccountDto>>> GetUserTransactions(Guid userId, DateTime startDate, DateTime endDate, int page, int limit, CancellationToken cancellationToken);
}
