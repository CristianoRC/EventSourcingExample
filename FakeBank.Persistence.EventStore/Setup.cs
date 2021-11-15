using FakeBank.Domain.Account.Repository;
using FakeBank.Domain.Transactions.Repository;
using FakeBank.Persistence.EventStore.Account;
using FakeBank.Persistence.EventStore.Transaction;
using Microsoft.Extensions.DependencyInjection;

namespace FakeBank.Persistence.EventStore
{
    public static class Setup
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
        }
    }
}