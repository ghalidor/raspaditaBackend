
using Application.CommandsQueries.Ticket_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;
using System.Globalization;

namespace Application.Handlers.Ticket_CommandsQueries;
public class SaldoTicketQueryHandler : IRequestHandler<SaldoTicketQuery, ticketSaldo>
{
    private readonly ITicketRepository _ticketRepository;
    private readonly ICajaRepository _cajalRepository;
    public SaldoTicketQueryHandler(ITicketRepository ticketRepository, ICajaRepository cajalRepository)
    {
        _ticketRepository = ticketRepository;
        _cajalRepository = cajalRepository;
    }
    public async Task<ticketSaldo> Handle(SaldoTicketQuery query, CancellationToken cancellationToken)
    {
        ticketSaldo ticket = new ticketSaldo();
        var tickets = await _ticketRepository.GetTicketSaldoxticket_id(query.ticket_id);
        tickets.fecharegistro_string = tickets.fecharegistro.ToString("dd-MM-yyyy") != "01-01-0001" ? tickets.fecharegistro.ToString("dd-MM-yyyy hh:mm:ss tt", CultureInfo.InvariantCulture) : "----";
        tickets.fechaupdated_string = tickets.fechaupdated.ToString("dd-MM-yyyy") != "01-01-0001" ? tickets.fechaupdated.ToString("dd-MM-yyyy hh:mm:ss tt", CultureInfo.InvariantCulture) : "----";
        tickets.estado_string = tickets.estado ? "ACTIVO" : "ANULADO";
        tickets.clase = tickets.estado ? "success" : "danger";
        return ticket;
    }
}
