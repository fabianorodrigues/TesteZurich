using Domain.Commands.Inputs;
using Domain.Commands.Outputs;
using Domain.Handlers;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SeguroController : Controller
    {
        private readonly ISeguroRepository _repository;
        private readonly SeguroHandler _handler;

        public SeguroController(ISeguroRepository repository, SeguroHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpPost]
        [Route("Calcular")]
        public IActionResult Calcular([FromBody]CalcularSeguroCommand command)
        {
            var result = (CommandResult)_handler.Calcular(command);
            return Ok(result.Value);
        }

        [HttpGet]
        [Route("ObterSeguro/{CPF}")]
        public IActionResult ObterSeguro(string CPF)
        {
            var result = (CommandResult)_handler.ObterSeguro(CPF);
            return Ok(result.Value);
        }
    }
}
