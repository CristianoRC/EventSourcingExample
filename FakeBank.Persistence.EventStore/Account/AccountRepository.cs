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

        private string generateCacheKey(Domain.Account.Entities.Account account)
        {
            return $"account-{account.Id.ToString()}";
        }

        public async Task CreateAccount(Domain.Account.Entities.Account account)
        {
            var key = generateCacheKey(account);
            var accountJson = JsonSerializer.Serialize(account);
            await _cache.SetAsync(key, new UTF8Encoding().GetBytes(accountJson));
        }
    }
}