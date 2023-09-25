using Application.CommandsQueries.TransaccionesCommandQueries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace raspaditaAPi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransaccionesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TransaccionesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetTransacciones")]
        public async Task<IActionResult> GetTransacciones()
        {
            string message = "Lista Transacciones";
            var data = await _mediator.Send(new GetTransaccionesQuery());
            return new OkObjectResult(new { message, data });
        }

        [HttpGet("GetTransaccionesxcajaPuntojuego_id/{caja_id}/{puntoJuego_id}")]
        public async Task<IActionResult> GetTransaccionesxcajaPuntojuego_id(int caja_id, int puntoJuego_id)
        {
            string message = "Lista transacciones x caja id x puntojuego";
            var data = await _mediator.Send(new GetTransaccionesxcajaPuntojuego_idQuery() { puntoJuego_id = puntoJuego_id, caja_id= caja_id });
            return new OkObjectResult(new { message, data });
        }

        [HttpPost("CreateTransaccion")]
        public async Task<IActionResult> CreateTransaccion([FromBody] transaccionesNuevo transacciones)
        {
            var command = new CreateTransaccionCommand() { NewTransacciones = transacciones };
            ServiceResponse response = await _mediator.Send(command);
            return new OkObjectResult(new { response });
        }

        [HttpPost("newScratch")]
        public async Task<IActionResult> newScratch([FromBody] transaccionesNuevo transacciones)
        {
            var command = new CreateTransaccionCommand() { NewTransacciones = transacciones };
            ServiceResponse response = await _mediator.Send(command);
            return new OkObjectResult(new { response });
        }
    }
}
