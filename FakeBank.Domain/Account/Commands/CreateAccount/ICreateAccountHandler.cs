using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FakeBank.Domain.Account.Queries;

namespace FakeBank.Domain.Account.Commands.CreateAccount
{
    public interface ICreateAccountHandler
    {
        Task<Guid> CreateAccount(CreateAccountCommand command);
    }
}