using Gringotts.Banking.Domain.Entities;
using Gringotts.Banking.Domain.Extensions;
using Gringotts.Banking.Shared.Abstractions;

namespace Gringotts.Banking.Domain.Repositories.Transactions;

public class TransactionRepository : ITransactionRepository
{
    private readonly BankingDbContext _dbContext;

    public TransactionRepository(BankingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Transaction entity)
    {
        _dbContext.Transactions.Add(entity);
    }

    public async Task<PagedResult<Transaction?>> GetAccountTransactionsAsync(Guid accountId, int page = 1, int limit = 10, CancellationToken cancellationToken = default)
    {
        var query = _dbContext.Transactions.Where(x => x.AccountId == accountId).OrderByDescending(x => x.CreatedOnUtc).AsQueryable();

        var result = await query.GetPagedResult(page, limit, cancellationToken);

        return result;
    }

    public async Task<PagedResult<Transaction?>> GetAccountTransactionsAsync(Guid accountId, DateTime? startDate, DateTime? endDate, int page = 1, int limit = 10, CancellationToken cancellationToken = default)
    {
        var query = _dbContext.Transactions.Where(x => x.AccountId == accountId && x.TransactionDate >= startDate && x.TransactionDate <= endDate).OrderByDescending(x => x.CreatedOnUtc).AsQueryable();

        var result = await query.GetPagedResult(page, limit, cancellationToken);

        return result;
    }

    public async Task<Transaction?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Transactions.FindAsync(id, cancellationToken);
    }

    public async Task<PagedResult<Transaction?>> GetUserTransactionsAsync(Guid userId, int page = 1, int limit = 10, CancellationToken cancellationToken = default)
    {
        var query = _dbContext.Transactions.Where(x => x.UserId == userId).OrderByDescending(x => x.CreatedOnUtc).AsQueryable();

        var result = await query.GetPagedResult(page, limit, cancellationToken);

        return result;
    }

    public async Task<PagedResult<Transaction?>> GetUserTransactionsAsync(Guid userId, DateTime? startDate, DateTime? endDate, int page = 1, int limit = 10, CancellationToken cancellationToken = default)
    {
        var query = _dbContext.Transactions.Where(x => x.UserId == userId && x.TransactionDate >= startDate && x.TransactionDate <= endDate).OrderByDescending(x => x.CreatedOnUtc).AsQueryable();

        var result = await query.GetPagedResult(page, limit, cancellationToken);

        return result;
    }
}
