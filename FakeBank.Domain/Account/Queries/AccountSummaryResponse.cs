using System.Collections.Generic;
using FakeBank.Domain.Transactions.Entities;

namespace FakeBank.Domain.Account.Queries
{
    public class AccountSummaryResponse
    {
        public AccountSummaryResponse(IEnumerable<Transaction> transactions, decimal amount)
        {
            Transactions = transactions;
            Amount = amount;
        }
        public IEnumerable<Transaction> Transactions { get; set; }
        public decimal Amount { get; set; }
    }
}