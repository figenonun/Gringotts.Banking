namespace Gringotts.Banking.Domain;

using Gringotts.Banking.Domain.Repositories.Accounts;
using Gringotts.Banking.Domain.Repositories.Transactions;
using Gringotts.Banking.Domain.Repositories.Users;
using Gringotts.Banking.Shared;
using Gringotts.Banking.Shared.DependencyInjection;


/// <summary>
/// SharedDataContext
/// </summary>
public class DataContext(
    LazyServiceProvider<UnitOfWork<BankingDbContext>> lazyUnitOfWork,
    LazyServiceProvider<IUserRepository> lazyUserRepository,
    LazyServiceProvider<IAccountRepository> lazyAccountRepository,
    LazyServiceProvider<ITransactionRepository> lazyTransactionRepository) :
    IDataContext
{
    /// <summary>
    /// UnitOfWork
    /// </summary>
    public IUnitOfWork UnitOfWork => lazyUnitOfWork.Value;

    /// <summary>
    /// Users
    /// </summary>
    public IUserRepository Users => lazyUserRepository.Value;

    /// <summary>
    /// Accounts
    /// </summary>
    public IAccountRepository Accounts => lazyAccountRepository.Value;
    /// <summary>
    /// Transactions
    /// </summary>
    public ITransactionRepository Transactions => lazyTransactionRepository.Value;
}
