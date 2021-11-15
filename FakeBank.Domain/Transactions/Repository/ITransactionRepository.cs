using System;
using System.Threading.Tasks;

namespace FakeBank.Domain.Transactions.Repository
{
    public interface ITransactionRepository
    {
        public Task AddNewTransaction(Entities.Transaction transaction);
    }
}