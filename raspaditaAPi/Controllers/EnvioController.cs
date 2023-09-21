
using Application.CommandsQueries.Envio_CommandQueries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace raspaditaAPi.Controllers
{
    [ApiController]
    public class EnvioController  : ControllerBase
    {
        private readonly IMediator _mediator;
        public EnvioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetEnvios")]
        public async Task<IActionResult> GetEnvios()
        {
            string message = "Lista Envios";
            var data = await _mediator.Send(new GetEnvioQuery());
            return new OkObjectResult(new { message, data });
        }

        [HttpGet("GetEnvioxPuntojuego/{puntoJuego_id}")]
        public async Task<IActionResult> GetEnvioxPuntojuego(Int64 puntoJuego_id)
        {
            string message = "Lista Envios x PuntoJuego";
            var data = await _mediator.Send(new GetEnvioxPuntojuego_idQuery() { puntoJuego_id = puntoJuego_id });
            return new OkObjectResult(new { message, data });
        }

        [HttpPost("CreateEnvio")]
        public async Task<IActionResult> CreateEnvio([FromBody] envioNuevo envio)
        {
            var command = new CreateEnvioCommand() { NewEnvio = envio };
            ServiceResponse response = await _mediator.Send(command);
            return new OkObjectResult(new { response });
        }
      
    }
}
