using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using FakeBank.Domain.Transactions.Entities;

namespace FakeBank.Domain.Transactions.Repository
{
    public interface ITransactionRepository
    {
        public Task<Transaction> AddNewTransaction(Transaction transaction);
        public Task<IEnumerable<Transaction>> GetTransactions(Guid accountId);
        public Task<decimal> GetAmount(Guid accountId);
    }
}