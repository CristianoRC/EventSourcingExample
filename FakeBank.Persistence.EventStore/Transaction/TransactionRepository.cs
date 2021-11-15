using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EventStore.ClientAPI;
using FakeBank.Domain.Transactions.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FakeBank.Persistence.EventStore.Transaction
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IConfiguration _config;
        private readonly ILogger<TransactionRepository> _logger;

        public TransactionRepository(IConfiguration config, ILogger<TransactionRepository> logger)
        {
            _config = config;
            _logger = logger;
        }

        public IEventStoreConnection CreateConnection()
        {
            var connectionString = new Uri(_config["EventStoreDB"]);

            var settings = ConnectionSettings.Create()
                .EnableVerboseLogging()
                .UseConsoleLogger()
                .DisableTls()
                .LimitReconnectionsTo(100)
                .Build();

            return EventStoreConnection.Create(settings, connectionString);
        }

        public async Task<Domain.Transactions.Entities.Transaction> AddNewTransaction(Domain.Transactions.Entities.Transaction transaction)
        {
            var transactionJson = JsonSerializer.Serialize(transaction);

            var streamName = "Transactions";
            var eventData = new EventData(
                eventId: Guid.NewGuid(),
                type: Enum.GetName(transaction.Type),
                isJson: true,
                data: Encoding.UTF8.GetBytes(transactionJson),
                metadata: Encoding.UTF8.GetBytes("{}")
            );
            var connection = CreateConnection();
            await connection.ConnectAsync();
            await connection.AppendToStreamAsync(streamName, ExpectedVersion.Any, eventData);

            return transaction;
        }
    }
}