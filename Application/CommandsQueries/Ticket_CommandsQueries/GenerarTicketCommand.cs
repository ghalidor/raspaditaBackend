
using Domain;
using MediatR;

namespace Application.CommandsQueries.Ticket_CommandsQueries
{
    public class GenerarTicketCommand : IRequest<ServiceResponseTicket>
    {
        public ticketNuevo NewTicket { get; set; }
    }
}
