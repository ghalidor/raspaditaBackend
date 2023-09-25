using Application.CommandsQueries.Scratch_CommandsQueries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace raspaditaAPi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScratchController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ScratchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("newScratch")]
        public async Task<IActionResult> newScratch(Int64 indice, string ip)
        {
            var data = await _mediator.Send(new NewScratchQuery() { indice = indice, ip = ip });
            return new OkObjectResult(data);
        }

        [HttpPost("newScratch")]
        public async Task<IActionResult> newScratch(Scratch_objectonew objeto)
        {
            var data = await _mediator.Send(new NewScratchQuery() { indice = objeto.indice, ip = objeto.ip });
            return new OkObjectResult(data);
        }

        [HttpPost("acreditacion")]
        public async Task<IActionResult> acreditacion(Scratch_objecto objeto)
        {
            var data = await _mediator.Send(new AcreditacionQuery() { ticket = objeto.ticket, ip = objeto.ip });
            return new OkObjectResult(data);
        }


        [HttpPost("jugada")]
        public async Task<IActionResult> jugada(Scratch_jugadaobjeto objeto)
        {
            var data = await _mediator.Send(new JugadaQuery() { objeto = objeto });
            return new OkObjectResult(data);
        }

        [HttpPost("cobrarCreditos")]
        public async Task<IActionResult> cobrarCreditos(Scratch_objecto objeto)
        {
            var data = await _mediator.Send(new CobrarCreditosCommand() { ip = objeto.ip,ticket=objeto.ticket });
            return new OkObjectResult(data);
        }

        [HttpGet("lastcode")]
        public async Task<IActionResult> lastcode()
        {
            var data = await _mediator.Send(new LastCodeQuery());
            return new OkObjectResult(data);
        }

    }

}