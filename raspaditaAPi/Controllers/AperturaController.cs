using Application.CommandsQueries.Apertura_CommandsQueries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace raspaditaAPi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AperturaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AperturaController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("GetAperturaxLocal_idxCaja_id/{local_id}/{caja_id}")]
        public async Task<IActionResult> GetAperturaxLocal_id(Int64 local_id, Int64 caja_id)
        {
            string message = "Lista Aperturas x Local x caja";
            var data = await _mediator.Send(new GetAperturaxlocal_idxcaja_idQuery() { local_id = local_id, caja_id = caja_id });
            return new OkObjectResult(new { message, data });
        }

        [HttpPost("CreateApertura")]
        public async Task<IActionResult> AperturarCaja(aperturaNuevo apertura)
        {
            var command = new AperturarCajaCommand() {local_id= apertura.local_id, caja_id = apertura.caja_id };
            ServiceResponse response = await _mediator.Send(command);
            return new OkObjectResult(response);
        }

        [HttpPost("CloseApertura")]
        public async Task<IActionResult> CloseApertura(aperturaCerrar apertura)
        {
            var command = new CloseAperturaCommand() { apertura = apertura };
            ServiceResponse response = await _mediator.Send(command);
            return new OkObjectResult(response);
        }
    }
}
