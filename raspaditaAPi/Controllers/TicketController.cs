

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

        [HttpPost("PagarSaldoTicket")]
        public async Task<IActionResult> PagarSaldoTicket([FromBody] string ticket)
        {
            var command = new PagarSaldoTicketCommand() { nroticket = ticket };
            ServiceResponseTicket response = await _mediator.Send(command);
            return new OkObjectResult(response);
        }

        [HttpPost("SaldoTicket")]
        public async Task<IActionResult> SaldoTicket([FromBody] Int64 ticket_id)
        {
            var command = new SaldoTicketQuery() { ticket_id = ticket_id };
            ticketSaldo response = await _mediator.Send(command);
            return new OkObjectResult(response);
        }


        [HttpPost("PagoTicket")]
        public async Task<IActionResult> PagoTicket([FromBody] ticketPagar ticket)
        {
            var command = new PagarSaldoTicketCommand() { caja_id = ticket.caja_id,nroticket=ticket.nroticket };
            ServiceResponseTicket response = await _mediator.Send(command);
            return new OkObjectResult(response);
        }
    }
}
