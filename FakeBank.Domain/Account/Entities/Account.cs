using System;
using FakeBank.Domain.ValueObjects;

namespace FakeBank.Domain.Account.Entities
{
    public class Account
    {
        public Account(Address address, Email email, string clientName, string password)
        {
            Id = Guid.NewGuid();
            Address = address;
            Email = email;
            ClientName = clientName;
            Password = password;
        }

        public Guid Id { get; }
        public string ClientName { get; }

        public string Password { get; set; }
        public Address Address { get; }
        public Email Email { get; }
    }
}