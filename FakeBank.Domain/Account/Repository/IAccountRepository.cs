using System;
using System.Threading.Tasks;
using FakeBank.Domain.Account.Queries;

namespace FakeBank.Domain.Account.Repository
{
    public interface IAccountRepository
    {
        Task<Guid> CreateAccount(Entities.Account account);
        public Task<bool> AccountExists(Guid accountId);
        Task<AccountSummaryResponse> GetAccountData(Guid account);
    }
}