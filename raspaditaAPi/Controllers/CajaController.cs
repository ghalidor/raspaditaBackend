using Application.CommandsQueries.Caja_CommandsQueries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace raspaditaAPi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CajaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CajaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCajas")]
        public async Task<IActionResult> GetCajas()
        {
            string message = "Lista Cajas";
           var data = await _mediator.Send(new GetCajasQuery());
            return new OkObjectResult(new { message, data });
        }

        [HttpGet("GetDetalleCaja/{id}")]
        public async Task<IActionResult> GetDetalleCaja(Int64 id)
        {
            string message = "Detalle Local";
            var data = await _mediator.Send(new GetDetalleCajaQuery() { id = id });
            return new OkObjectResult(new { message, data });
        }

        [HttpGet("GetCajasxLocal_id/{local_id}")]
        public async Task<IActionResult> GetCajasxLocal_id(Int64 local_id)
        {
            string message = "Lista Cajas x Local";
            var data = await _mediator.Send(new GetCajaxLocal_idQuery() { local_id = local_id});
            return new OkObjectResult(new { message, data });
        }

        [HttpPost("CreateCaja")]
        public async Task<IActionResult> CreateCaja([FromBody] cajaNuevo caja)
        {
            var command = new CreateCajaCommand() { NewCaja = caja };
            ServiceResponse response = await _mediator.Send(command);
            return new OkObjectResult(response);
        }

        [HttpPost("UpdateCaja")]
        public async Task<IActionResult> UpdateCaja([FromBody] cajaEditar caja)
        {
            var command = new UpdateCajaCommand() { EditCaja = caja };
            ServiceResponse response = await _mediator.Send(command);
            return new OkObjectResult(response);
        }
    }
}
