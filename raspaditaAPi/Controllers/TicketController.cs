

using Application.CommandsQueries.Ticket_CommandsQueries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace raspaditaAPi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController  : ControllerBase
    {
        private readonly IMediator _mediator;
        public TicketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetTicketxCaja_id/{caja_id}")]
        public async Task<IActionResult> GetTicketxCaja_id(Int64 caja_id)
        {
            string message = "Lista Tickets x caja";
            var data = await _mediator.Send(new GetTicketsCajaQuery() { caja_id = caja_id });
            return new OkObjectResult(new { message, data });
        }


        [HttpPost("GenerarTicket")]
        public async Task<IActionResult> GenerarTicket([FromBody] ticketNuevo ticket)
        {
            var command = new GenerarTicketCommand() { NewTicket = ticket };
            ServiceResponseTicket response = await _mediator.Send(command);
            return new OkObjectResult(response);
        }
    }
}
