using FakeBank.Domain.Account.Commands;
using FakeBank.Domain.Account.Commands.CreateAccount;
using Microsoft.Extensions.DependencyInjection;

namespace FakeBank.Domain
{
    public static class Setup
    {
        public static void AddDomain(this IServiceCollection services)
        {
            services.AddTransient<ICreateAccountHandler, CreateAccountHandler>();
        }
    }
}