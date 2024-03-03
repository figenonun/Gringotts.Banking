namespace Gringotts.Banking.Domain.Repositories.Users;

using Gringotts.Banking.Domain.Entities;
using Gringotts.Banking.Shared.Abstractions;
using System.Linq.Expressions;

public interface IUserRepository
{
    void Add(User entity);

    Task<bool> IsExist(Guid id, CancellationToken cancellationToken = default);

    Task<User?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    Task<PagedResult<User>> SearchUser(List<Expression<Func<User, bool>>> predicates, int page = 1, int limit = 10, CancellationToken cancellationToken = default);
}
