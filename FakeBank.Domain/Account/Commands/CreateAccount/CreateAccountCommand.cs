namespace FakeBank.Domain.Account.Commands.CreateAccount
{
    public class CreateAccountCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Street { get; }
        public string City { get; }
        public string ZipCode { get; }
    }
}