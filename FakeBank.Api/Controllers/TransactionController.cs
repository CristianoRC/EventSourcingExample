using System;
using System.Threading.Tasks;
using FakeBank.Domain.Transactions.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FakeBank.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : Controller
    {
        private readonly ITransactionCommandHandler _handler;
        private readonly ILogger<TransactionController> _logger;

        public TransactionController(ITransactionCommandHandler handler, ILogger<TransactionController> logger)
        {
            _handler = handler;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreteTransaction([FromBody] CreateTransactionCommand command)
        {
            try
            {
                var transaction = await _handler.AddTransaction(command);
                return Created("", transaction);
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