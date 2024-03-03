using Gringotts.Banking.Domain.Entities;
using Gringotts.Banking.Domain.Extensions;
using Gringotts.Banking.Shared.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Gringotts.Banking.Domain.Repositories.Users;

public class UserRepository : IUserRepository
{
    private readonly BankingDbContext _dbContext;

    public UserRepository(BankingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(User entity)
    {
        _dbContext.Users.Add(entity);
    }

    public async Task<User?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users.FindAsync(id, cancellationToken);
    }

    public async Task<bool> IsExist(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users.AnyAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<PagedResult<User>> SearchUser(List<Expression<Func<User, bool>>> predicates, int page = 1, int limit = 10, CancellationToken cancellationToken = default)
    {
        var query = _dbContext.Users.AsQueryable();

        foreach (var item in predicates)
        {
            query = query.Where(item);
        }

        query = query.OrderByDescending(x => x.CreatedOnUtc);

        return await query.GetPagedResult(page, limit, cancellationToken);
    }
}
