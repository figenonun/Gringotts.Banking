using Azure;
using Gringotts.Banking.Application.Contracts.Transactions;
using Gringotts.Banking.Application.Contracts.Transactions.Dto;
using Gringotts.Banking.Domain.Entities;
using Gringotts.Banking.Domain.Repositories.Accounts;
using Gringotts.Banking.Domain.Repositories.Transactions;
using Gringotts.Banking.Shared.Abstractions;
using Microsoft.Identity.Client;
using System.Collections.Generic;

namespace Gringotts.Banking.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _repository;

        public TransactionService(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<PagedResult<TransactionDto>>> GetAccountTransactionsAsync(Guid accountId, DateTime? startDate, DateTime? endDate, int page = 1, int limit = 10, CancellationToken cancellationToken = default)
        {
            var accountTransactions = await _repository.GetAccountTransactionsAsync(accountId, startDate, endDate, page, limit, cancellationToken);

            var transactions = new List<TransactionDto>();

            foreach (var item in accountTransactions.Items)
            {

                transactions.Add(new TransactionDto
                {
                    Id = item.Id,
                    AccountId = item.AccountId,
                    Amount = item.Amount,
                    Currency = item.Currency,
                    TransactionDate = item.TransactionDate,
                    TransactionType = item.TransactionType,
                    UserId = item.UserId

                });
            }

            var result = new PagedResult<TransactionDto>
            {
                Items = transactions,
                PageSize = accountTransactions.PageSize,
                TotalPageCount = accountTransactions.TotalPageCount,
                CurrentPage = accountTransactions.CurrentPage,
                TotalItemCount = accountTransactions.TotalItemCount,
            };

            return result;

        }

        public async Task<PagedResult<TransactionDto?>> GetAccountTransactionsAsync(Guid accountId, int page = 1, int limit = 10, CancellationToken cancellationToken = default)
        {
            var accountTransactions = await _repository.GetAccountTransactionsAsync(accountId, page, limit, cancellationToken);

            var transactions = new List<TransactionDto>();

            foreach (var item in accountTransactions.Items)
            {

                transactions.Add(new TransactionDto
                {
                    Id = item.Id,
                    AccountId = item.AccountId,
                    Amount = item.Amount,
                    Currency = item.Currency,
                    TransactionDate = item.TransactionDate,
                    TransactionType = item.TransactionType,
                    UserId = item.UserId

                });
            }

            var result = new PagedResult<TransactionDto>
            {
                Items = transactions,
                PageSize = accountTransactions.PageSize,
                TotalPageCount = accountTransactions.TotalPageCount,
                CurrentPage = accountTransactions.CurrentPage,
                TotalItemCount = accountTransactions.TotalItemCount,
            };

            return result;

        }

        public async Task<TransactionDto?> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var accountTransaction = await _repository.GetAsync(id, cancellationToken);

            var transaction = new TransactionDto
            {
                Id = accountTransaction.Id,
                AccountId = accountTransaction.AccountId,
                Amount = accountTransaction.Amount,
                Currency = accountTransaction.Currency,
                TransactionDate = accountTransaction.TransactionDate,
                TransactionType = accountTransaction.TransactionType,
                UserId = accountTransaction.UserId
            };

            return transaction;
        }

        public async Task<Result<PagedResult<TransactionDto>>> GetUserTransactionsAsync(Guid userId, DateTime? startDate, DateTime? endDate, int page = 1, int limit = 10, CancellationToken cancellationToken = default)
        {
            var accountTransactions = await _repository.GetUserTransactionsAsync(userId, startDate, endDate, page, limit, cancellationToken);

            var transactions = new List<TransactionDto>();

            foreach (var item in accountTransactions.Items)
            {

                transactions.Add(new TransactionDto
                {
                    Id = item.Id,
                    AccountId = item.AccountId,
                    Amount = item.Amount,
                    Currency = item.Currency,
                    TransactionDate = item.TransactionDate,
                    TransactionType = item.TransactionType,
                    UserId = item.UserId

                });
            }

            var result = new PagedResult<TransactionDto>
            {
                Items = transactions,
                PageSize = accountTransactions.PageSize,
                TotalPageCount = accountTransactions.TotalPageCount,
                CurrentPage = accountTransactions.CurrentPage,
                TotalItemCount = accountTransactions.TotalItemCount,
            };

            return result;
        }

        public async Task<PagedResult<TransactionDto?>> GetUserTransactionsAsync(Guid userId, int page = 1, int limit = 10, CancellationToken cancellationToken = default)
        {
            var accountTransactions = await _repository.GetUserTransactionsAsync(userId, page, limit, cancellationToken);

            var transactions = new List<TransactionDto>();

            foreach (var item in accountTransactions.Items)
            {

                transactions.Add(new TransactionDto
                {
                    Id = item.Id,
                    AccountId = item.AccountId,
                    Amount = item.Amount,
                    Currency = item.Currency,
                    TransactionDate = item.TransactionDate,
                    TransactionType = item.TransactionType,
                    UserId = item.UserId

                });
            }

            var result = new PagedResult<TransactionDto>
            {
                Items = transactions,
                PageSize = accountTransactions.PageSize,
                TotalPageCount = accountTransactions.TotalPageCount,
                CurrentPage = accountTransactions.CurrentPage,
                TotalItemCount = accountTransactions.TotalItemCount,
            };

            return result;
        }
    }
}
