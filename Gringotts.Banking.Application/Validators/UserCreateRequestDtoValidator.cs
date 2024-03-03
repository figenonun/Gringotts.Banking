using FluentValidation;
using Gringotts.Banking.Application.Contracts.Users.Dto;
using Gringotts.Banking.Domain.Errors;
using Gringotts.Banking.Shared.Extensions;

namespace Gringotts.Banking.Application.Validators
{
    internal class UserCreateRequestDtoValidator : AbstractValidator<UserCreateRequest>
    {
        public UserCreateRequestDtoValidator()
        {
            RuleFor(s => s.FirstName).NotEmpty().WithError(UserErrors.FirstNameInvalid);

            RuleFor(s => s.LastName).NotEmpty().WithError(UserErrors.LastNameInvalid);

            RuleFor(s => s.PhoneNumber).NotEmpty().WithError(UserErrors.PhoneNumberInvalid);

            RuleFor(s => s.CitizenshipNumber).NotEmpty().GreaterThan(0).WithError(UserErrors.CitizenshipNumberInvalid);

            RuleFor(s => s.Password).NotEmpty().WithError(UserErrors.PasswordInvalid);
        }
    }
}
