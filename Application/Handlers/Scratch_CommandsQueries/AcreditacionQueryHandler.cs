
using Application.CommandsQueries.Scratch_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.Scratch_CommandsQueries
{
    public class AcreditacionQueryHandler : IRequestHandler<AcreditacionQuery, Scratch_monto>
    {
        private readonly IScratchRepository _scratchRepository;
        private readonly IPuntoJuegoRepository _puntoJuegoRepository;
        private readonly ITicketRepository _ticketRepository;
        public AcreditacionQueryHandler(IScratchRepository scratchRepository, IPuntoJuegoRepository puntoJuegoRepository, ITicketRepository ticketRepository)
        {
            _scratchRepository = scratchRepository;
            _puntoJuegoRepository = puntoJuegoRepository;
            _ticketRepository = ticketRepository;
        }
        public async Task<Scratch_monto> Handle(AcreditacionQuery query, CancellationToken cancellationToken)
        {
            if (query.ip is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }
            Scratch_monto nuevo = new Scratch_monto();
            string ip = query.ip;
            string ticket = query.ticket;
            var puntojuego = await _puntoJuegoRepository.GetPuntoJuegoDetallexIp(query.ip);
            var tickets = await _ticketRepository.GetTicketSaldoxticket_nro(query.ticket);
            if(tickets == null)
            {
                nuevo.monto = 0;
            }
            else
            {
                if(tickets.acreditado)
                {
                    nuevo.monto = 0;
                }
                else
                {
                    nuevo.monto = tickets.saldoticketfin;
                    await _ticketRepository.UpdateTicketAcreditado(true, tickets.ticket_id, puntojuego.id);
                }
            }
            return nuevo;
        }
    }
}

