using Gringotts.Banking.Application.Contracts.Accounts.Dto;
using Gringotts.Banking.Application.Contracts.Users;
using Gringotts.Banking.Application.Contracts.Users.Dto;
using Gringotts.Banking.Application.Validators;
using Gringotts.Banking.Domain.Entities;
using Gringotts.Banking.Domain.Errors;
using Gringotts.Banking.Domain.Repositories.Users;
using Gringotts.Banking.Shared;
using Gringotts.Banking.Shared.Abstractions;

namespace Gringotts.Banking.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUserRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> CreateAsync(UserCreateRequest userCreateRequest, CancellationToken cancellationToken = default)
        {
            var validator = new UserCreateRequestDtoValidator();

            var validationResult = validator.Validate(userCreateRequest);

            if (!validationResult.IsValid)
            {
                return Result.Failure(new Error(Int32.Parse(validationResult.Errors.First().ErrorCode), validationResult.Errors.First().ErrorCode, validationResult.Errors.First().ErrorMessage));

            }

            var user = User.CreateUser(
                userCreateRequest.Email,
                userCreateRequest.FirstName,
                userCreateRequest.LastName,
                userCreateRequest.CitizenshipNumber,
                userCreateRequest.PhoneNumber,
                userCreateRequest.Password);

            _repository.Add(user);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        public async Task<Result<UserDto>> GetAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            var user = await _repository.GetAsync(userId, cancellationToken);

            if (user == null)
            {
                return UserErrors.NotFound;
            }

            var userDto = new UserDto
            {
                Id = userId,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                CitizenshipNumber = user.CitizenshipNumber,
                PhoneNumber = user.PhoneNumber
            };

            return userDto;
        }

        public async Task<Result<bool>> IsExistAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return await _repository.IsExist(userId, cancellationToken);
        }
    }
}
