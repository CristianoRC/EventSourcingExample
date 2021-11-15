using System;
using FakeBank.Domain.Transactions.Enums;

namespace FakeBank.Domain.Transactions.Commands
{
    public class CreateTransactionCommand
    {
        public CreateTransactionCommand(string password, Guid accountId, decimal amount, ETransactionType transactionType)
        {
            Password = password;
            AccountId = accountId;
            Amount = amount;
            TransactionType = transactionType;
        }
        
        public string Password { get; set; }
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
        public ETransactionType TransactionType { get; set; }
    }
}