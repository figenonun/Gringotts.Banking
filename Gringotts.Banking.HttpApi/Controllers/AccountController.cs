
namespace Gringotts.Banking.HttpApi.Controllers;

using Gringotts.Banking.Application.Contracts.Accounts;
using Gringotts.Banking.Application.Contracts.Accounts.Dto;
using Gringotts.Banking.HttpApi.Authentication;
using Gringotts.Banking.Shared.Abstractions;
using Gringotts.Banking.Shared.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[BasicAuthorization]
[ApiController]
[Route($"api/accounts")]
public class AccountController(IAccountService accountService) : ControllerBase
{
    /// <summary>
    /// Get 
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Result<AccountDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var result = await accountService.GetAsync(id, cancellationToken);

        return Ok(result);
    }

    /// <summary>
    /// Get 
    /// </summary>
    [HttpGet("")]
    [ProducesResponseType(typeof(Result<List<AccountDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(Guid userId,
        Guid id, CancellationToken cancellationToken)
    {
        var result = await accountService.GetAccountsByUserIdAsync(userId, cancellationToken);

        return Ok(result);
    }

    /// <summary>
    /// Create
    /// </summary>
    [HttpPost("")]
    [ProducesResponseType(typeof(Result<AccountDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create(AccountCreateDto accountCreateDto, CancellationToken cancellationToken)
    {
        var result = await accountService.CreateAsync(accountCreateDto, cancellationToken);

        return Ok(result);
    }

    /// <summary>
    /// deposit
    /// </summary>
    [HttpPost("deposit")]
    [ProducesResponseType(typeof(Result<AccountDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Deposit(Guid accountId, decimal amount, CancellationToken cancellationToken)
    {
        var result = await accountService.DepositAsync(accountId, amount, cancellationToken);

        return Ok(result);
    }

    /// <summary>
    /// Withdraw
    /// </summary>
    [HttpPost("withdraw")]
    [ProducesResponseType(typeof(Result<AccountDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Withdraw(Guid accountId, decimal amount, CancellationToken cancellationToken)
    {
        var result = await accountService.WithdrawAsync(accountId, amount, cancellationToken);

        return Ok(result);
    }

    /// <summary>
    /// Get user balance
    /// </summary>
    [HttpGet("transactions/{id}")]
    [ProducesResponseType(typeof(Result<AccountDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAccountTransaction(Guid id, Guid accountId, CancellationToken cancellationToken)
    {
        var result = await accountService.GetAccountTransactionById(id, accountId, cancellationToken);

        return Ok(result);
    }

    /// <summary>
    /// Get user balance
    /// </summary>
    [HttpGet("account-transactions")]
    [ProducesResponseType(typeof(Result<AccountDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAccountTransactions(Guid accountId, int page, int limit, CancellationToken cancellationToken)
    {
        var result = await accountService.GetAccountTransactions(accountId, page, limit, cancellationToken);

        return Ok(result);
    }


    /// <summary>
    /// Get user balance
    /// </summary>
    [HttpGet("user-transactions")]
    [ProducesResponseType(typeof(Result<AccountDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUserTransactions(Guid userId, DateTime startDate, DateTime endDate, int page, int limit, CancellationToken cancellationToken)
    {
        var result = await accountService.GetUserTransactions(userId, startDate, endDate, page, limit, cancellationToken);

        return Ok(result);
    }
}
