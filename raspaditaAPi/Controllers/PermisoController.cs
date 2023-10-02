using Application.CommandsQueries.Permiso_CommandsQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using raspaditaAPi.utilities;

namespace raspaditaAPi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermisoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;
        public PermisoController(IMediator mediator, IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
            _mediator = mediator;
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
        }

        [HttpGet("SincronizarPermisos")]
        public async Task<IActionResult> SincronizarPermisos()
        {
            ControllerMethods routes = new ControllerMethods(_actionDescriptorCollectionProvider);
            string message = "Permisos Sincronizados";
            var data = await _mediator.Send(new SincronizarPermisosCommand(){listapermisos=routes.listaControladores().ToList() });
            return new OkObjectResult(new { message, respuesta = data });
        }
    }
}
