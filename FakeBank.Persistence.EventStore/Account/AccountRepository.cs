using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FakeBank.Domain.Account.Repository;
using Microsoft.Extensions.Caching.Distributed;

namespace FakeBank.Persistence.EventStore.Account
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IDistributedCache _cache;

        public AccountRepository(IDistributedCache cache)
        {
            _cache = cache;
        }

        private string generateCacheKey(Guid accountId)
        {
            return $"account-{accountId.ToString()}";
        }

        public async Task CreateAccount(Domain.Account.Entities.Account account)
        {
            var key = generateCacheKey(account.Id);
            var accountJson = JsonSerializer.Serialize(account);
            await _cache.SetAsync(key, new UTF8Encoding().GetBytes(accountJson));
        }

        public async Task<bool> AccountExists(Guid accountId)
        {
            var key = generateCacheKey(accountId);
            var account = await _cache.GetAsync(key);
            return account is not null;
        }
    }
}