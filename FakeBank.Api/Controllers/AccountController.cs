using System;
using System.Threading.Tasks;
using FakeBank.Domain.Account.Commands;
using FakeBank.Domain.Account.Commands.CreateAccount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FakeBank.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly ICreateAccountHandler _accountService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(ICreateAccountHandler accountService, ILogger<AccountController> logger)
        {
            _accountService = accountService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountCommand accountCommand)
        {
            try
            {
                await _accountService.CreateAccount(accountCommand);
                return NoContent();
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

        [HttpGet]
        public IActionResult GetAccounts()
        {
            return Ok();
        }
    }
}