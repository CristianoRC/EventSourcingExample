using System;

namespace FakeBank.Domain.Account.Entities
{
    public class Account
    {
        public Account(Client client, string password)
        {
            Id = Guid.NewGuid();
            Client = client;
            Password = password;
        }

        public Guid Id { get; }
        public Client Client { get; }
        public string Password { get; }
    }
}