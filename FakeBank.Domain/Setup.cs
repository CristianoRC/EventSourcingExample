using FakeBank.Domain.Account.Commands.CreateAccount;
using FakeBank.Domain.Account.Services.Password;
using FakeBank.Domain.Transactions.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace FakeBank.Domain
{
    public static class Setup
    {
        public static void AddDomain(this IServiceCollection services)
        {
            services.AddTransient<ICreateAccountHandler, CreateAccountHandler>();
            services.AddTransient<ITransactionCommandHandler, TransactionCommandHandler>();
            services.AddTransient<IPasswordServices, PasswordServices>();
        }
    }
}