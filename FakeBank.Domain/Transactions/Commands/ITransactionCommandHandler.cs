using System.Threading.Tasks;
using FakeBank.Domain.Transactions.Entities;

namespace FakeBank.Domain.Transactions.Commands
{
    public interface ITransactionCommandHandler
    {
        Task<Transaction> AddTransaction(CreateTransactionCommand command);
    }
}