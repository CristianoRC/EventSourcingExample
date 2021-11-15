using System;
using System.Threading.Tasks;
using FakeBank.Domain.Transactions.Entities;

namespace FakeBank.Domain.Transactions.Repository
{
    public interface ITransactionRepository
    {
        public Task<Transaction> AddNewTransaction(Transaction transaction);
    }
}