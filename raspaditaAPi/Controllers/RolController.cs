using Application.CommandsQueries.Rol_CommandsQueries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace raspaditaAPi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RolController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetRol")]
        public async Task<IActionResult> GetRol()
        {
            string message = "Lista Roles";
            var data = await _mediator.Send(new GetRolQuery());
            return new OkObjectResult(new { message, data });
        }

        [HttpGet("GetDetalleRol/{id}")]
        public async Task<IActionResult> GetDetalleRol(Int64 id)
        {
            string message = "Detalle Local";
            var data = await _mediator.Send(new GetDetalleRolQuery() { id = id });
            return new OkObjectResult(new { message, data });
        }

        [HttpPost("CreateRol")]
        public async Task<IActionResult> CreateRol([FromBody] rolNuevo rol)
        {
            var command = new CreateRolCommand() { NewRol = rol };
            ServiceResponse response = await _mediator.Send(command);
            return new OkObjectResult(response);
        }

        [HttpPost("UpdateRol")]
        public async Task<IActionResult> UpdateCaja([FromBody] rolEditar rol)
        {
            var command = new UpdateRolCommand() { EditRol = rol };
            ServiceResponse response = await _mediator.Send(command);
            return new OkObjectResult(response);
        }
    }

}
