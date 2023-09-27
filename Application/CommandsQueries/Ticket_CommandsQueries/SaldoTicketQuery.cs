

using Domain;
using MediatR;

namespace Application.CommandsQueries.Ticket_CommandsQueries;
public class SaldoTicketQuery : IRequest<ticketSaldo>
{
    public Int64 ticket_id { get; set; }
}
