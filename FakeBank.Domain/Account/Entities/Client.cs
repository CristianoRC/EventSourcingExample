using FakeBank.Domain.Account.ValueObjects;

namespace FakeBank.Domain.Account.Entities
{
    public class Client
    {
        public Client(Name name, Address address, Email email)
        {
            Name = name;
            Address = address;
            Email = email;
        }

        public Name Name { get; }
        public Address Address { get; }
        public Email Email { get; }
    }
}