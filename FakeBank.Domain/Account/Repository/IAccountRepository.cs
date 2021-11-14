using System.Threading.Tasks;

namespace FakeBank.Domain.Account.Repository
{
    public interface IAccountRepository
    {
        Task CreateAccount(Entities.Account account);
    }
}