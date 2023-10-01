
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
        private readonly ICajaRepository _cajaRepository;
        private readonly IPuntoJuegoRepository _puntojuegoRepository;
        public GetTicketsCajaQueryHandler(ITicketRepository ticketRepository, ICajaRepository cajaRepository, IPuntoJuegoRepository puntojuegoRepository)
        {
           _ticketRepository = ticketRepository;
            _cajaRepository = cajaRepository;
            _puntojuegoRepository = puntojuegoRepository;
        }
        public async Task<IEnumerable<ticket>> Handle(GetTicketsCajaQuery query, CancellationToken cancellationToken)
        {
            List<ticket> lista = new List<ticket>();
            //var tickets = await _ticketRepository.GetTicketsxCaja_id(query.caja_id);
            DateTime fechahoy = DateTime.Now;
            var tickets = await _ticketRepository.GetTicketsxCaja_idxfecha(query.caja_id, fechahoy);
            var caja = await _cajaRepository.GetDetalleCaja(query.caja_id);
            var puntosjuegos = await _puntojuegoRepository.GetPuntoJuegoxLocal_id(caja.local_id);
            foreach(var item in tickets)
            {
                item.fecharegistro_string = item.fecharegistro.ToString("dd-MM-yyyy") != "01-01-0001" ? item.fecharegistro.ToString("dd-MM-yyyy hh:mm:ss tt", CultureInfo.InvariantCulture) : "----";
                item.fechacobro_string = item.fechacobro.ToString("dd-MM-yyyy") != "01-01-0001" ? item.fechacobro.ToString("dd-MM-yyyy hh:mm:ss tt", CultureInfo.InvariantCulture) : "----";
                item.estado_string = item.estado ? "ACTIVO" : "PAGADO";
                item.clase = item.estado ? "success" : "warning";
                item.puntojuego_ip = item.puntojuego_id!=0? puntosjuegos.Where(x => x.id == item.puntojuego_id).Select(z => z.ip).FirstOrDefault():"-";
                item.puntojuego_nombre = item.puntojuego_id != 0 ? puntosjuegos.Where(x => x.id == item.puntojuego_id).Select(z => z.nro_punto).FirstOrDefault().ToString() : "-";
                lista.Add(item);
            }
            return lista;
        }
    }
}
