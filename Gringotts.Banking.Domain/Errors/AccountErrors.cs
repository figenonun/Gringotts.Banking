namespace Gringotts.Banking.Domain.Errors;

using Gringotts.Banking.Shared.Abstractions;

public static class AccountErrors
{
    public static readonly Error AccountNotFound = new(1205, "Account.AccountNotFound", "Account balance not exist");

    public static readonly Error AmountMustBePositive = new(1207, "Account.AmountMustBePositive", "Requested amount is invalid, must be positive");

    public static readonly Error InsufficientBalance = new(1206, "Account.InsufficientBalance", "Insufficient balance");

    public static readonly Error AccountInvalid = new(1200, "Account.Id.Invalid", "Account Id is empty or invalid");

    public static readonly Error AccountCurrencyInvalid = new(1208, "Account.Currenct.Invalid", "Account Currency is empty or invalid");
}
