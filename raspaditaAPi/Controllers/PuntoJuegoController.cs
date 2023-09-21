using Application.CommandsQueries.PuntoJuego_CommandsQueries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace raspaditaAPi.Controllers
{
    public class PuntoJuegoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PuntoJuegoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetPuntoJuego")]
        public async Task<IActionResult> GetPuntoJuego()
        {
            string message = "Lista Punto Juegos";
            var data = await _mediator.Send(new GetPuntoJuegoQuery());
            return new OkObjectResult(new { message, data });
        }

        [HttpGet("GetPuntoJuegoxLocal_id/{local_id}")]
        public async Task<IActionResult> GetPuntoJuegoxLocal_id(Int64 local_id)
        {
            string message = "Lista PuntoJuego x local id";
            var data = await _mediator.Send(new GetPuntoJuegoxLocal_idQuery() { local_id = local_id });
            return new OkObjectResult(new { message, data });
        }

        [HttpPost("CreatePuntoJuego")]
        public async Task<IActionResult> CreatePuntoJuego([FromBody] puntojuegoNuevo envio)
        {
            var command = new CreatePuntoJuegoCommand() { NewPuntoJuego = envio };
            ServiceResponse response = await _mediator.Send(command);
            return new OkObjectResult(new { response });
        }
    }
}
