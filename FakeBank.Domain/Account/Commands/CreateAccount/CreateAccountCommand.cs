namespace FakeBank.Domain.Account.Commands
{
    public class CreateAccountCommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Street { get; }
        public string City { get; }
        public string ZipCode { get; }
    }
}