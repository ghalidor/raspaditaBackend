using Application.CommandsQueries.Local_CommandsQueries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace raspaditaAPi.Controllers
{
    [ApiController]
    public class LocalController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LocalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ListarLocales")]
        public async Task<IActionResult> ListarLocales()
        {
            string message = "Lista Locales";
            var data = await _mediator.Send(new GetLocalQuery());
            return new OkObjectResult(new { message, data });
        }

        [HttpGet("DetalleLocal/{id}")]
        public async Task<IActionResult> DetalleLocal(Int64 id)
        {
            string message = "Detalle Local";
            var data = await _mediator.Send(new GetDetalleLocalQuery() { local_id=id });
            return new OkObjectResult(new { message, data });
        }

        [HttpPost("CreateLocal")]
        public async Task<IActionResult> CreateLocal([FromBody] localNuevo local)
        {
            var command = new CreateLocalCommand() { NewLocal = local };
            ServiceResponse response = await _mediator.Send(command);
            return new OkObjectResult(new { response });
        }
    }
}
