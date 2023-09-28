
using Application.CommandsQueries.Scratch_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.Scratch_CommandsQueries
{
    public class CobrarCreditosCommandHandler : IRequestHandler<CobrarCreditosCommand, Scratch_response>
    {
        private readonly IScratchRepository _scratchRepository;
        private readonly IPuntoJuegoRepository _puntoJuegoRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly ITransaccionesRepository _transaccionesRepository;
        public CobrarCreditosCommandHandler(IScratchRepository scratchRepository, IPuntoJuegoRepository puntoJuegoRepository, ITicketRepository ticketRepository, ITransaccionesRepository transaccionesRepository)
        {
            _scratchRepository = scratchRepository;
            _puntoJuegoRepository = puntoJuegoRepository;
            _ticketRepository = ticketRepository;
            _transaccionesRepository = transaccionesRepository;
        }
        public async Task<Scratch_response> Handle(CobrarCreditosCommand query, CancellationToken cancellationToken)
        {
            if (query.ip is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }
            Scratch_response nuevo = new Scratch_response();
            var puntojuego = await _puntoJuegoRepository.GetPuntoJuegoDetallexIp(query.ip);
            var tickets = await _ticketRepository.GetTicketSaldoxticket_nro(query.ticket);
            bool respuesta = await _transaccionesRepository.Estadocobro(tickets.transaccion_id,true);
           
            nuevo.response = respuesta;
            return nuevo;
        }
    }

}
