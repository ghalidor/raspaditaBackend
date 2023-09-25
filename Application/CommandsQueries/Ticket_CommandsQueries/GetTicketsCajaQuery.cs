using Domain;
using MediatR;

namespace Application.CommandsQueries.Ticket_CommandsQueries
{
    public class GetTicketsCajaQuery : IRequest<IEnumerable<ticket>>
    {
        public Int64 caja_id { get; set; }
    }
}
