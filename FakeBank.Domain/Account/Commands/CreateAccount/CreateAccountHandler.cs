using System.Threading.Tasks;
using FakeBank.Domain.Account.Entities;
using FakeBank.Domain.Account.Repository;
using FakeBank.Domain.Account.ValueObjects;

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
            var name = new Name(command.FirstName, command.LastName);
            var address = new Address(command.Street, command.City, command.ZipCode);
            var email = new Email(command.Email);

            var client = new Client(name, address, email);

            var account = new Entities.Account(client, command.Password);
            await _repository.CreateAccount(account);
        }
    }
}