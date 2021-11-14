using System.Threading.Tasks;

namespace FakeBank.Domain.Account.Commands.CreateAccount
{
    public interface ICreateAccountHandler
    {
        Task CreateAccount(CreateAccountCommand command);
    }
}