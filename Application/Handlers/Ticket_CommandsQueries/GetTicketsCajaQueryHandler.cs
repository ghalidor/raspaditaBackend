
using Application.CommandsQueries.Ticket_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;
using System.Globalization;

namespace Application.Handlers.Ticket_CommandsQueries
{
    public class GetTicketsCajaQueryHandler : IRequestHandler<GetTicketsCajaQuery, IEnumerable<ticket>>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly ICajaRepository _cajalRepository;
        public GetTicketsCajaQueryHandler(ITicketRepository ticketRepository, ICajaRepository cajalRepository)
        {
           _ticketRepository = ticketRepository;
            _cajalRepository = cajalRepository;
        }
        public async Task<IEnumerable<ticket>> Handle(GetTicketsCajaQuery query, CancellationToken cancellationToken)
        {
            List<ticket> lista = new List<ticket>();
            var tickets = await _ticketRepository.GetTicketsxCaja_id(query.caja_id);
            foreach(var item in tickets)
            {
                item.fecharegistro_string = item.fecharegistro.ToString("dd-MM-yyyy") != "01-01-0001" ? item.fecharegistro.ToString("dd-MM-yyyy hh:mm:ss tt", CultureInfo.InvariantCulture) : "----";
                item.fechaupdated_string = item.fechaupdated.ToString("dd-MM-yyyy") != "01-01-0001" ? item.fechaupdated.ToString("dd-MM-yyyy hh:mm:ss tt", CultureInfo.InvariantCulture) : "----";
                item.estado_string = item.estado ? "ACTIVO" : "ANULADO";
                item.clase = item.estado ? "success" : "danger";
                lista.Add(item);
            }
            return lista;
        }
    }
}
