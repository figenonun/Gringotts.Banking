using Azure.Core;
using Gringotts.Banking.Application.Contracts.Accounts;
using Gringotts.Banking.Application.Contracts.Accounts.Dto;
using Gringotts.Banking.Application.Contracts.Transactions;
using Gringotts.Banking.Application.Contracts.Transactions.Dto;
using Gringotts.Banking.Application.Validators;
using Gringotts.Banking.Domain.Entities;
using Gringotts.Banking.Domain.Errors;
using Gringotts.Banking.Domain.Repositories.Accounts;
using Gringotts.Banking.Shared;
using Gringotts.Banking.Shared.Abstractions;
using Gringotts.Banking.Shared.Enums;

namespace Gringotts.Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITransactionService _transactionService;

        public AccountService(IAccountRepository repository, IUnitOfWork unitOfWork, ITransactionService transactionService)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _transactionService = transactionService;
        }
        public async Task<Result<AccountDto>> CreateAsync(AccountCreateDto accountCreateDto, CancellationToken cancellationToken)
        {

            var validator = new AccountCreateDtoValidator();

            var validationResult = validator.Validate(accountCreateDto);

            if (!validationResult.IsValid)
            {

                return new Error(Int32.Parse(validationResult.Errors.First().ErrorCode), validationResult.Errors.First().ErrorCode, validationResult.Errors.First().ErrorMessage);

            }

            var account = new Account(
                      accountCreateDto.UserId,
                      accountCreateDto.Currency);

            _repository.Add(account);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new AccountDto
            {
                Id = account.Id,
                UserId = account.UserId,
                Currency = account.Currency,
                Total = account.Total,
                Locked = account.Locked,
                Available = account.Available,
                CreatedOnUtc = account.CreatedOnUtc,
                ModifiedOnUtc = account.ModifiedOnUtc
            };
        }

        public async Task<Result<AccountDto>> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var account = await _repository.GetAsync(id, cancellationToken);

            if (account == null)
            {
                return AccountErrors.AccountNotFound;
            }

            return new AccountDto
            {
                Id = account.Id,
                UserId = account.UserId,
                Currency = account.Currency,
                Total = account.Total,
                Locked = account.Locked,
                Available = account.Available,
                CreatedOnUtc = account.CreatedOnUtc,
                ModifiedOnUtc = account.ModifiedOnUtc
            };
        }
        public async Task<Result<List<AccountDto>>> GetAccountsByUserIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            var accounts = await _repository.GetAccountsByUserIdAsync(userId, cancellationToken);

            var result = accounts
                .Select(account => new AccountDto
                {
                    Id = account.Id,
                    UserId = account.UserId,
                    Currency = account.Currency,
                    Total = account.Total,
                    Locked = account.Locked,
                    Available = account.Available,
                    CreatedOnUtc = account.CreatedOnUtc,
                    ModifiedOnUtc = account.ModifiedOnUtc
                })
                .ToList();

            return result;
        }

        public async Task<Result> DepositAsync(
        Guid accountId,
        decimal amount,
        CancellationToken cancellationToken)
        {
            var account = await _repository.GetAsync(accountId, cancellationToken);

            if (account == null)
            {
                return AccountErrors.AccountNotFound;
            }

            var depositResult = account.Deposit(TransactionType.Deposit, amount, DateTime.UtcNow);

            if (depositResult.IsSuccess)
            {

                await _unitOfWork.SaveChangesAsync();
            }

            return depositResult;
        }
        public async Task<Result> CanWithdrawAsync(Guid accountId, decimal amount, CancellationToken cancellationToken)
        {
            var account = await _repository.GetAsync(accountId, cancellationToken);

            if (account == null)
            {
                return AccountErrors.AccountNotFound;
            }

            var canWithDrawResult = account.CanWithdraw(amount);

            return canWithDrawResult;
        }

        public async Task<Result> WithdrawAsync(
       Guid accountId,
       decimal amount,
       CancellationToken cancellationToken)
        {
            var account = await _repository.GetAsync(accountId, cancellationToken);

            if (account == null)
            {
                return AccountErrors.AccountNotFound;
            }

            var withdrawResult = account.Withdraw(TransactionType.Withdraw, amount, DateTime.UtcNow);

            if (withdrawResult.IsSuccess)
            {
                await _unitOfWork.SaveChangesAsync();
            }

            return withdrawResult;
        }

        public async Task<Result> LockBalanceAsync(Guid accountId, decimal amount, CancellationToken cancellationToken)
        {
            var account = await _repository.GetAsync(accountId, cancellationToken);

            if (account == null)
            {
                return AccountErrors.AccountNotFound;
            }

            var lockResult = account.LockBalance(amount);

            if (lockResult.IsSuccess)
            {
                await _unitOfWork.SaveChangesAsync();
            }

            return lockResult;
        }
        public async Task<Result> CanReleaseLockedBalanceAsync(Guid accountId, decimal amount, CancellationToken cancellationToken)
        {
            var account = await _repository.GetAsync(accountId, cancellationToken);

            if (account == null)
            {
                return AccountErrors.AccountNotFound;
            }

            var canReleaseResult = account.CanReleaseLockedBalance(amount);

            return canReleaseResult;
        }


        public async Task<Result> ReleaseLockedBalanceAsync(Guid accountId, decimal amount, CancellationToken cancellationToken)
        {
            var account = await _repository.GetAsync(accountId, cancellationToken);

            if (account == null)
            {
                return AccountErrors.AccountNotFound;
            }

            var releaseLockedResult = account.ReleaseLockedBalance(amount);

            if (releaseLockedResult.IsSuccess)
            {
                await _unitOfWork.SaveChangesAsync();
            }

            return releaseLockedResult;
        }

        public async Task<Result<AccountDto>> GetAccountTransactionById(Guid transactionId, Guid accountId, CancellationToken cancellationToken)
        {
            var account = await _repository.GetAsync(accountId, cancellationToken);

            if (account == null)
            {
                return AccountErrors.AccountNotFound;
            }

            var transaction = await _transactionService.GetAsync(transactionId, cancellationToken);

            var transactions = new List<TransactionDto>();
            if (transaction != null)
            {
                transactions.Add(transaction);

            }
            var result = new AccountDto
            {
                Id = account.Id,
                UserId = account.UserId,
                Available = account.Available,
                Currency = account.Currency,
                Locked = account.Locked,
                Total = account.Total,
                Transactions = transactions,
                CreatedOnUtc = account.CreatedOnUtc,
                ModifiedOnUtc = account.ModifiedOnUtc
            };

            return result;
        }

        public async Task<Result<AccountDto>> GetAccountTransactions(Guid accountId, int page, int limit, CancellationToken cancellationToken)
        {

            var account = await _repository.GetAsync(accountId, cancellationToken);

            if (account == null)
            {
                return AccountErrors.AccountNotFound;
            }

            var transaction = await _transactionService.GetAccountTransactionsAsync(accountId, page, limit, cancellationToken);

            var transactions = new List<TransactionDto>();

            if (transaction.Items != null)
            {
                transactions.AddRange(transaction.Items);

            }
            var result = new AccountDto
            {
                Id = account.Id,
                UserId = account.UserId,
                Available = account.Available,
                Currency = account.Currency,
                Locked = account.Locked,
                Total = account.Total,
                Transactions = transactions,
                CreatedOnUtc = account.CreatedOnUtc,
                ModifiedOnUtc = account.ModifiedOnUtc
            };

            return result;
        }

        public async Task<Result<List<AccountDto>>> GetUserTransactions(Guid userId, DateTime startDate, DateTime endDate, int page, int limit, CancellationToken cancellationToken)
        {
            var userAccountsTransactions = new List<AccountDto>();

            var accounts = await _repository.GetAccountsByUserIdAsync(userId, cancellationToken);

            if (!accounts.Any())
            {
                return AccountErrors.AccountNotFound;
            }

            var userTransactions = await _transactionService.GetUserTransactionsAsync(userId, startDate, endDate, page, limit, cancellationToken);

            var transactions = new List<TransactionDto>();

            if (userTransactions.Value.Items != null)
            {
                transactions.AddRange(userTransactions.Value.Items);

            }
            foreach (var account in accounts)
            {
                userAccountsTransactions.Add(new AccountDto
                {
                    Id = account.Id,
                    UserId = account.UserId,
                    Available = account.Available,
                    Currency = account.Currency,
                    Locked = account.Locked,
                    Total = account.Total,
                    Transactions = transactions,
                    CreatedOnUtc = account.CreatedOnUtc,
                    ModifiedOnUtc = account.ModifiedOnUtc
                });
            }

            return userAccountsTransactions;
        }
    }
}
