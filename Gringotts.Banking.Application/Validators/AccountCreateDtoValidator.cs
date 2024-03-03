using FluentValidation;
using Gringotts.Banking.Application.Contracts.Accounts.Dto;
using Gringotts.Banking.Domain.Errors;
using Gringotts.Banking.Shared.Extensions;

namespace Gringotts.Banking.Application.Validators;

public class AccountCreateDtoValidator : AbstractValidator<AccountCreateDto>
{
    public AccountCreateDtoValidator()
    {
        RuleFor(s => s.UserId).NotEmpty().WithError(UserErrors.NotFound);

        RuleFor(s => s.Currency).NotEmpty().WithError(AccountErrors.AccountCurrencyInvalid);
    }
}
