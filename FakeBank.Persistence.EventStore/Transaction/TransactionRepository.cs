using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EventStore.ClientAPI;
using FakeBank.Domain.Transactions.Enums;
using FakeBank.Domain.Transactions.Repository;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FakeBank.Persistence.EventStore.Transaction
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IConfiguration _config;
        private readonly ILogger<TransactionRepository> _logger;
        private readonly IDistributedCache _cache;
        private string streamName = "Transactions";

        public TransactionRepository(IConfiguration config, ILogger<TransactionRepository> logger,
            IDistributedCache cache)
        {
            _config = config;
            _logger = logger;
            _cache = cache;
        }

        private string GenerateAmountCacheKey(Guid accountId)
        {
            return $"account-balance-{accountId.ToString()}";
        }

        private IEventStoreConnection CreateConnection()
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

        public async Task<Domain.Transactions.Entities.Transaction> AddNewTransaction(
            Domain.Transactions.Entities.Transaction transaction)
        {
            var transactionJson = JsonSerializer.Serialize(transaction);
            var eventData = new EventData(
                eventId: Guid.NewGuid(),
                type: Enum.GetName(transaction.Type),
                isJson: true,
                data: Encoding.UTF8.GetBytes(transactionJson),
                metadata: Encoding.UTF8.GetBytes("{}")
            );
            using var connection = CreateConnection();
            await connection.ConnectAsync();
            await connection.AppendToStreamAsync(streamName, ExpectedVersion.Any, eventData);

            await UpdateAmount(transaction.TransactionId, transaction.Amount, transaction.Type);

            return transaction;
        }

        public async Task<IEnumerable<Domain.Transactions.Entities.Transaction>> GetTransactions(Guid accountId)
        {
            using var connection = CreateConnection();
            await connection.ConnectAsync();
            var transactions = new List<Domain.Transactions.Entities.Transaction>();

            StreamEventsSlice readEvents;
            var startStream = 0;

            do
            {
                readEvents = await connection.ReadStreamEventsForwardAsync(streamName, startStream, 100, true);
                foreach (var evt in readEvents.Events)
                {
                    var transactionJson = Encoding.UTF8.GetString(evt.Event.Data);
                    var transaction =
                        JsonSerializer.Deserialize<Domain.Transactions.Entities.Transaction>(transactionJson);
                    transactions.Add(transaction);
                    startStream += 100;
                }
            } while (readEvents.Events.Length is not 0);


            return transactions;
        }

        private async Task UpdateAmount(Guid account, decimal transactionAmount, ETransactionType transactionType)
        {
            //TODO: O correto seria usar o client e somar direto no banco*

            var currentAmount = await GetAmount(account);

            if (transactionType == ETransactionType.Credit)
                currentAmount += transactionAmount;
            else
                currentAmount -= transactionAmount;

            var key = GenerateAmountCacheKey(account);
            await _cache.SetAsync(key, Encoding.UTF8.GetBytes(currentAmount.ToString(CultureInfo.InvariantCulture)));
        }

        public async Task<decimal> GetAmount(Guid accountId)
        {
            var key = GenerateAmountCacheKey(accountId);
            var amount = await _cache.GetStringAsync(key);
            return amount is null ? 0 : decimal.Parse(amount);
        }
    }
}