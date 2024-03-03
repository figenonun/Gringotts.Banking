using Gringotts.Banking.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Gringotts.Banking.Domain.Repositories.Accounts;

public class AccountRepository : IAccountRepository
{
    private readonly BankingDbContext _dbContext;

    public AccountRepository(BankingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Account account)
    {
        _dbContext.Accounts.Add(account);
    }

    public async Task<List<Account>> GetAccountsByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var accounts = await _dbContext
           .Accounts
           .Where(account => account.UserId == userId)
           .ToListAsync();

        return accounts;
    }

    public async Task<Account?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var account = await _dbContext
                   .Accounts
                   .FirstOrDefaultAsync(x => x.Id == id);

        return account;
    }
}
