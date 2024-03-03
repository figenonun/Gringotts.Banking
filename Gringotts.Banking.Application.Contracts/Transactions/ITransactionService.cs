using Gringotts.Banking.Application.Contracts.Transactions.Dto;
using Gringotts.Banking.Shared.Abstractions;


namespace Gringotts.Banking.Application.Contracts.Transactions;

public interface ITransactionService
{

    /// <summary>
    /// Get Account Transactions
    /// </summary>
    Task<Result<PagedResult<TransactionDto>>> GetAccountTransactionsAsync(Guid accountId, DateTime? startDate, DateTime? endDate, int page = 1, int limit = 10, CancellationToken cancellationToken = default);

    // <summary>
    // Get Account Transactions
    // </summary>
    Task<PagedResult<TransactionDto?>> GetAccountTransactionsAsync(Guid accountId, int page = 1, int limit = 10, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get User Transactions
    /// </summary>
    Task<Result<PagedResult<TransactionDto>>> GetUserTransactionsAsync(Guid userId, DateTime? startDate, DateTime? endDate, int page = 1, int limit = 10, CancellationToken cancellationToken = default);

    // <summary>
    // Get User Transactions
    // </summary>
    Task<PagedResult<TransactionDto?>> GetUserTransactionsAsync(Guid userId, int page = 1, int limit = 10, CancellationToken cancellationToken = default);


    /// <summary>
    /// Get By id
    /// </summary>
    Task<TransactionDto?> GetAsync(Guid id, CancellationToken cancellationToken = default);
}
