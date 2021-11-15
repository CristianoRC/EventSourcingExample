using System.Threading.Tasks;

namespace FakeBank.Domain.Transactions.Commands
{
    public interface ITransactionCommandHandler
    {
        Task AddTransaction(CreateTransactionCommand command);
    }
}