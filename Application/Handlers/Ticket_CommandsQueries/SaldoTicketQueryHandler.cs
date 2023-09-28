
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
        ticketSaldo ticketSaldo = new ticketSaldo();
        var tickets = await _ticketRepository.GetTicketSaldoxticket_id(query.ticket_id);
        if(tickets != null){
            
            if(tickets.estadopago)
            {
                ticketSaldo.message = "Ticket de pago Generado "+tickets.comprobantepagonro;
            }
            else
            {
                ticketSaldo.message = "Registro de Ticket : " + tickets.nroticket;

            }
            ticketSaldo.estadopago=tickets.estadopago;
            ticketSaldo.id = tickets.ticket_id;
            ticketSaldo.caja_id = tickets.caja_id;
            ticketSaldo.nroticket=tickets.nroticket;
            ticketSaldo.nroticketpago = tickets.comprobantepagonro;
            ticketSaldo.monto = tickets.monto;
            ticketSaldo.fecharegistro_string = tickets.fecharegistro.ToString("dd-MM-yyyy") != "01-01-0001" ? tickets.fecharegistro.ToString("dd-MM-yyyy hh:mm:ss tt", CultureInfo.InvariantCulture) : "----";          
            ticketSaldo.fechapago_string = tickets.fechacobro.ToString("dd-MM-yyyy") != "01-01-0001" ? tickets.fechacobro.ToString("dd-MM-yyyy hh:mm:ss tt", CultureInfo.InvariantCulture) : "----";
            ticketSaldo.response = true;

        }
        else
        {
            ticketSaldo.response = false;
            ticketSaldo.message = "Ticket no encontrado";
        }
       
        return ticketSaldo;
    }
}
