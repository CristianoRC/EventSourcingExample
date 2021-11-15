using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FakeBank.Domain.Account.Queries;
using FakeBank.Domain.Account.Repository;
using FakeBank.Domain.Transactions.Repository;
using Microsoft.Extensions.Caching.Distributed;

namespace FakeBank.Persistence.EventStore.Account
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IDistributedCache _cache;
        private readonly ITransactionRepository _transactionRepository;

        public AccountRepository(IDistributedCache cache, ITransactionRepository transactionRepository)
        {
            _cache = cache;
            _transactionRepository = transactionRepository;
        }

        private string generateAccountCacheKey(Guid accountId)
        {
            return $"account-{accountId.ToString()}";
        }

        public async Task<Guid> CreateAccount(Domain.Account.Entities.Account account)
        {
            var key = generateAccountCacheKey(account.Id);
            var accountJson = JsonSerializer.Serialize(account);
            await _cache.SetAsync(key, Encoding.UTF8.GetBytes(accountJson));
            return account.Id;
        }

        public async Task<bool> AccountExists(Guid accountId)
        {
            var key = generateAccountCacheKey(accountId);
            var account = await _cache.GetAsync(key);
            return account is not null;
        }

        public async Task<AccountSummaryResponse> GetAccountData(Guid account)
        {
            var accountExists = await AccountExists(account);
            if (!accountExists)
                throw new ArgumentException("Conta informada não existe");

            var transactions = await _transactionRepository.GetTransactions(account);
            var amount = await _transactionRepository.GetAmount(account);
            return new AccountSummaryResponse(transactions, amount);
        }
    }
}