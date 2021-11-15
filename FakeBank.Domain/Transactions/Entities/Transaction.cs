using System;
using FakeBank.Domain.Transactions.Enums;

namespace FakeBank.Domain.Transactions.Entities
{
    public class Transaction
    {
        public Transaction(Guid accountId, ETransactionType type, decimal amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException("O valor precisa ser prositivo!");

            Account = accountId;
            Type = type;
            Amount = amount;
        }

        public Guid Account { get; }
        public ETransactionType Type { get; }
        public decimal Amount { get; }
    }
}