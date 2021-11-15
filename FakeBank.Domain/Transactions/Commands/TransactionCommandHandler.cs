using System;
using System.Threading.Tasks;
using FakeBank.Domain.Account.Services.Password;
using FakeBank.Domain.Transactions.Entities;
using FakeBank.Domain.Transactions.Repository;

namespace FakeBank.Domain.Transactions.Commands
{
    public class TransactionCommandHandler : ITransactionCommandHandler
    {
        private readonly IPasswordServices _passwordServices;
        private readonly ITransactionRepository _repository;

        public TransactionCommandHandler(IPasswordServices passwordServices, ITransactionRepository repository)
        {
            _passwordServices = passwordServices;
            _repository = repository;
        }

        public async Task AddTransaction(CreateTransactionCommand command)
        {
            var passwordIsValid = await _passwordServices.PasswordIsValid(command.AccountId, command.Password);
            if (!passwordIsValid)
                throw new ArgumentException("A senha informada é inválida");

            var transaction = new Transaction(command.AccountId, command.TransactionType, command.Amount);

            await _repository.AddNewTransaction(transaction);
        }
    }
}