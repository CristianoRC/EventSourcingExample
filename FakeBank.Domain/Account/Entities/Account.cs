using System;
using FakeBank.Domain.Account.ValueObjects;

namespace FakeBank.Domain.Account.Entities
{
    public class Account
    {
        public Account(Client client, string password)
        {
            Id = Guid.NewGuid();
            Client = client;
            Password = new Password(password);
        }

        public Guid Id { get; }
        public Client Client { get; }
        public Password Password { get; }
    }
}