
namespace Gringotts.Banking.Domain
{
    using Gringotts.Banking.Domain.Repositories.Accounts;
    using Gringotts.Banking.Domain.Repositories.Transactions;
    using Gringotts.Banking.Domain.Repositories.Users;
    using Gringotts.Banking.Shared;

    /// <summary>
    /// ISharedDataContext
    /// </summary>
    public interface IDataContext
    {
        /// <summary>
        /// UnitOfWork
        /// </summary>
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// Users
        /// </summary>
        IUserRepository Users { get; }
        
        /// <summary>
        /// Accounts
        /// </summary>
        IAccountRepository Accounts { get; }
        
        /// <summary>
        /// Transactions
        /// </summary>
        ITransactionRepository Transactions { get; }  
    }
}
