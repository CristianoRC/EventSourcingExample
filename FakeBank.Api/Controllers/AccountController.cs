using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FakeBank.Domain.Account.Commands;
using FakeBank.Domain.Account.Commands.CreateAccount;
using FakeBank.Domain.Account.Queries;
using FakeBank.Domain.Account.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FakeBank.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly ICreateAccountHandler _accountService;
        private readonly IAccountRepository _repository;
        private readonly ILogger<AccountController> _logger;

        public AccountController(ICreateAccountHandler accountService, IAccountRepository repository,
            ILogger<AccountController> logger)
        {
            _accountService = accountService;
            _repository = repository;
            _logger = logger;
        }


        [HttpGet("[controller]/{account}")]
        public async Task<IActionResult> GetAccountData([FromRoute] Guid account)
        {
            try
            {
                var accountData = await _repository.GetAccountData(account);
                return Ok(accountData);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                //TODO: Implementar outras validações de erros
                _logger.LogError("Ocorreu um erro inesperado", e);
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountCommand accountCommand)
        {
            try
            {
                var accountId = await _accountService.CreateAccount(accountCommand);
                return Created(string.Empty, new {accountId});
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                //TODO: Implementar outras validações de erros
                _logger.LogError("Ocorreu um erro inesperado", e);
                return StatusCode(500);
            }
        }
    }
}