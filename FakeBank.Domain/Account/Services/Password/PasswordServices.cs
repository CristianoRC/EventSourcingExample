using System;
using System.Threading.Tasks;

namespace FakeBank.Domain.Account.Services.Password
{
    public class PasswordServices : IPasswordServices
    {
        public async Task<bool> PasswordIsValid(Guid accountId, string password)
        {
            try
            {
                new ValueObjects.Password(password);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}