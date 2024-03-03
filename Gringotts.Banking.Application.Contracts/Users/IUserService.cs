using Gringotts.Banking.Application.Contracts.Users.Dto;
using Gringotts.Banking.Shared.Abstractions;

namespace Gringotts.Banking.Application.Contracts.Users;


public interface IUserService
{
    Task<Result> CreateAsync(UserCreateRequest userCreateRequest, CancellationToken cancellationToken = default);

    Task<Result<bool>> IsExistAsync(Guid userId, CancellationToken cancellationToken = default);

    Task<Result<UserDto>> GetAsync(Guid userId, CancellationToken cancellationToken = default);
}
