using System.Threading.Tasks;
using FakeBank.Domain.Account.Repository;

namespace FakeBank.Persistence.EventStore.Account
{
    public class AccountRepository: IAccountRepository
    {
        public async Task CreateAccount(Domain.Account.Entities.Account account)
        {
            
        }
    }
}