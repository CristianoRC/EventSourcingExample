using System;
using System.Threading.Tasks;

namespace FakeBank.Domain.Account.Services.Password
{
    public  class PasswordServices : IPasswordServices
    {
        public Task<bool> PasswordIsValid(Guid accountId, string password)
        {
            throw new NotImplementedException();
        }
    }
}