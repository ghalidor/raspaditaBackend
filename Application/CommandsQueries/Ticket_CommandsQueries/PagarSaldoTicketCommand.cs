
using Domain;
using MediatR;

namespace Application.CommandsQueries.Ticket_CommandsQueries
{
    public class PagarSaldoTicketCommand : IRequest<ServiceResponseTicket>
    {
        public string nroticket { get; set; }
        public Int64 caja_id { get; set; }
    }
}
