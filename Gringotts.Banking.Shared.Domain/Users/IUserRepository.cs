namespace Papara.Investment.Shared.Domain.Users;

using Papara.Investment.Framework.Ddd.Abstractions;
using System.Linq.Expressions;

public interface IUserRepository
{
    void Add(User entity);

    Task<bool> IsExist(Guid id, CancellationToken cancellationToken = default);

    Task<User?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    //Task<User?> GetWithBalancesAndAccount(string id);

    //Task<User?> GetWithAccount(string id);

    Task<PagedResult<User>> GetAll(int page = 1, int limit = 10, CancellationToken cancellationToken = default);

    //Task<List<AccountEntity>> GetUserAccounts(string userid);

    //Task<User?> GetUserByCitizenshipNumber(long citizenshipNumber);

    Task<PagedResult<User>> SearchUser(List<Expression<Func<User, bool>>> predicates, int page = 1, int limit = 10, CancellationToken cancellationToken = default);
}