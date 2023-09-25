using Application.CommandsQueries.Local_CommandsQueries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace raspaditaAPi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocalController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LocalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetLocales")]
        public async Task<IActionResult> GetLocales()
        {
            string message = "Lista Locales";
            var data = await _mediator.Send(new GetLocalQuery());
            return new OkObjectResult(new { message, data });
        }

        [HttpGet("GetDetalleLocal/{id}")]
        public async Task<IActionResult> GetDetalleLocal(Int64 id)
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
            return new OkObjectResult(response);
        }

        [HttpPost("UpdateLocal")]
        public async Task<IActionResult> UpdateLocal([FromBody] localEditar local)
        {
            var command = new UpdateLocalCommand() { EditLocal = local };
            ServiceResponse response = await _mediator.Send(command);
            return new OkObjectResult(response);
        }
    }
}
