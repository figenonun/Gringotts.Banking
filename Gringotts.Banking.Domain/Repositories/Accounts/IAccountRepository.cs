using Gringotts.Banking.Domain.Entities;
using Gringotts.Banking.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gringotts.Banking.Domain.Repositories.Accounts
{
    public interface IAccountRepository : IRepository
    {
        void Add(Account account);

        Task<Account?> GetAsync(Guid id, CancellationToken cancellationToken = default);

        Task<List<Account>> GetAccountsByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
    }
}
