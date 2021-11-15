using System;
using FakeBank.Domain.Transactions.Enums;

namespace FakeBank.Domain.Transactions.Entities
{
    public class Transaction
    {
        public Transaction()
        {
        }

        public Transaction(Guid accountId, ETransactionType type, decimal amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException("O valor precisa ser prositivo!");

            Account = accountId;
            Type = type;
            Amount = amount;
            TransactionId = Guid.NewGuid();
        }

        public Guid TransactionId { get; set; }
        public Guid Account { get; set; }
        public ETransactionType Type { get; set; }
        public decimal Amount { get; set; }
    }
}