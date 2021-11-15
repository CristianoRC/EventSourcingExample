using System;
using System.Threading.Tasks;
using FakeBank.Domain.Account.Repository;
using FakeBank.Domain.Account.Services.Password;
using FakeBank.Domain.Transactions.Entities;
using FakeBank.Domain.Transactions.Repository;

namespace FakeBank.Domain.Transactions.Commands
{
    public class TransactionCommandHandler : ITransactionCommandHandler
    {
        private readonly IPasswordServices _passwordServices;
        private readonly ITransactionRepository _repository;
        private readonly IAccountRepository _accountRepository;

        public TransactionCommandHandler(IPasswordServices passwordServices, ITransactionRepository repository,
            IAccountRepository accountRepository)
        {
            _passwordServices = passwordServices;
            _repository = repository;
            _accountRepository = accountRepository;
        }

        public async Task<Transaction> AddTransaction(CreateTransactionCommand command)
        {
            var accountExists = await _accountRepository.AccountExists(command.AccountId);
            if (!accountExists)
                throw new ArgumentException("Conta não existe");

            //TODO: Verificar também se a senha é a real.
            var passwordIsValid = await _passwordServices.PasswordIsValid(command.AccountId, command.Password);
            if (!passwordIsValid)
                throw new ArgumentException("A senha informada é inválida");

            var transaction = new Transaction(command.AccountId, command.TransactionType, command.Amount);

            return await _repository.AddNewTransaction(transaction);
        }
    }
}