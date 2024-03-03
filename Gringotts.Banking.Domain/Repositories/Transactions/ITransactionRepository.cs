namespace Gringotts.Banking.Domain.Repositories.Transactions;

using Gringotts.Banking.Domain.Entities;
using Gringotts.Banking.Shared;
using Gringotts.Banking.Shared.Abstractions;

/// <summary>
/// ITransaction Repository
/// </summary>
public interface ITransactionRepository : IRepository
{
    // <summary>
    // Add Transaction
    // </summary>
    void Add(Transaction entity);

    // <summary>
    // Get Account Transactions by date range
    // </summary>
    Task<PagedResult<Transaction?>> GetAccountTransactionsAsync(Guid accountId, DateTime? startDate, DateTime? endDate, int page = 1, int limit = 10, CancellationToken cancellationToken = default);

    // <summary>
    // Get Account Transactions
    // </summary>
    Task<PagedResult<Transaction?>> GetAccountTransactionsAsync(Guid accountId, int page = 1, int limit = 10, CancellationToken cancellationToken = default);

    // <summary>
    // Get Account Transactions by date range
    // </summary>
    Task<PagedResult<Transaction?>> GetUserTransactionsAsync(Guid userId, DateTime? startDate, DateTime? endDate, int page = 1, int limit = 10, CancellationToken cancellationToken = default);

    // <summary>
    // Get Account Transactions
    // </summary>
    Task<PagedResult<Transaction?>> GetUserTransactionsAsync(Guid userId, int page = 1, int limit = 10, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get By id
    /// </summary>
    Task<Transaction?> GetAsync(Guid id, CancellationToken cancellationToken = default);

}
