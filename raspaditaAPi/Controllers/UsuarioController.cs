using Application.CommandsQueries.Usuario_CommandsQueries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace raspaditaAPi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IMediator _mediator;
        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetUsuarios")]
        public async Task<IActionResult> GetUsuarios()
        {
            string message = "Lista Usuarios";
            var data = await _mediator.Send(new GetUsuariosQuery());
            return new OkObjectResult(new { message, data });
        }

        [HttpGet("GetDetalleUsuario/{id}")]
        public async Task<IActionResult> GetDetalleUsuario(Int64 id)
        {
            string message = "Detalle Usuario";
            var data = await _mediator.Send(new GetDetalleUsuarioQuery() { id = id });
            return new OkObjectResult(new { message, data });
        }

        [HttpGet("GetUsuariosxLocal_id/{local_id}")]
        public async Task<IActionResult> GetUsuariosxLocal_id(Int64 local_id)
        {
            string message = "Usuarios x Local";
            var data = await _mediator.Send(new GetUsuariosxLocal_idQuery() { local_id = local_id });
            return new OkObjectResult(new { message, data });
        }

        [HttpPost("CreateUsuario")]
        public async Task<IActionResult> CreateUsuario([FromBody] usuarioNuevo usuario)
        {
            var command = new CreateUsuarioCommand() { NewUsuario = usuario };
            ServiceResponse response = await _mediator.Send(command);
            return new OkObjectResult(response);
        }

        [HttpPost("UpdateUsuario")]
        public async Task<IActionResult> UpdateUsuario([FromBody] usuarioEditar usuario)
        {
            var command = new UpdateUsuarioCommand() { EditUsuario = usuario };
            ServiceResponse response = await _mediator.Send(command);
            return new OkObjectResult(response);
        }
    }
}
