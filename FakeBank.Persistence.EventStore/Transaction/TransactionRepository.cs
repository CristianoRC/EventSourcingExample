using System;
using System.Threading.Tasks;
using FakeBank.Domain.Transactions.Repository;

namespace FakeBank.Persistence.EventStore.Transaction
{
    public class TransactionRepository : ITransactionRepository
    {
        public Task AddNewTransaction(Domain.Transactions.Entities.Transaction transaction)
        {
            throw new System.NotImplementedException();
        }
    }
}