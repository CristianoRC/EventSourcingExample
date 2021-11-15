using System;
using System.Threading.Tasks;

namespace FakeBank.Domain.Account.Services.Password
{
    public interface IPasswordServices
    {
        Task<bool> PasswordIsValid(Guid accountId, string password);
    }
}