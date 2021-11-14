using System.Threading.Tasks;
using FakeBank.Domain.Account.Repository;
using FakeBank.Domain.ValueObjects;

namespace FakeBank.Domain.Account.Commands.CreateAccount
{
    public class CreateAccountHandler : ICreateAccountHandler
    {
        private readonly IAccountRepository _repository;

        public CreateAccountHandler(IAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateAccount(CreateAccountCommand command)
        {
            var address = new Address(command.Street, command.City, command.ZipCode);
            var email = new Email(command.Email);

            var account = new Entities.Account(address, email, command.Name, command.Password);
            await _repository.CreateAccount(account);
        }
    }
}