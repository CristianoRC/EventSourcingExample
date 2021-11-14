using FakeBank.Domain.Account.Repository;
using FakeBank.Persistence.EventStore.Account;
using Microsoft.Extensions.DependencyInjection;

namespace FakeBank.Persistence.EventStore
{
    public static class Setup
    {
        public static void AddDomain(this IServiceCollection services)
        {
            services.AddTransient<IAccountRepository, AccountRepository>();
        }
    }
}