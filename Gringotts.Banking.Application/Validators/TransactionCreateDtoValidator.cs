using FluentValidation;
using Gringotts.Banking.Application.Contracts.Transactions.Dto;
using Gringotts.Banking.Domain.Errors;
using Gringotts.Banking.Shared.Extensions;

namespace Gringotts.Banking.Application.Validators
{
    internal class TransactionCreateDtoValidator : AbstractValidator<TransactionCreateDto>
    {
        public TransactionCreateDtoValidator()
        {
            RuleFor(s => s.AccountId).NotEmpty().WithError(AccountErrors.AccountInvalid);

            RuleFor(s => s.UserId).NotEmpty().WithError(UserErrors.UserIdInvalid);

            RuleFor(s => s.Amount).NotEmpty().GreaterThan(0).WithError(TransactionErrors.AmountInvalid);

            RuleFor(s => s.TransactionType).NotEmpty().WithError(TransactionErrors.TransactionTypeInvalid);

            RuleFor(s => s.Currency).NotEmpty().WithError(AccountErrors.AccountCurrencyInvalid);
        }
    }
}
