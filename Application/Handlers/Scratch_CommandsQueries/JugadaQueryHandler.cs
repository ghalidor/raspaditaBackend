
using Application.CommandsQueries.Scratch_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.Scratch_CommandsQueries
{
    public class JugadaQueryHandler : IRequestHandler<JugadaQuery, Scratch_jugada>
    {
        private readonly IScratchRepository _scratchRepository;
        private readonly IPuntoJuegoRepository _puntoJuegoRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly ITransaccionesRepository _transaccionesRepository;
        public JugadaQueryHandler(IScratchRepository scratchRepository, IPuntoJuegoRepository puntoJuegoRepository, ITicketRepository ticketRepository, ITransaccionesRepository transaccionesRepository)
        {
            _scratchRepository = scratchRepository;
            _puntoJuegoRepository = puntoJuegoRepository;
            _ticketRepository = ticketRepository;
            _transaccionesRepository = transaccionesRepository;
        }
        public async Task<Scratch_jugada> Handle(JugadaQuery query, CancellationToken cancellationToken)
        {
            if (query.objeto is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }
            Scratch_jugada nuevo = new Scratch_jugada();


            var puntojuego = await _puntoJuegoRepository.GetPuntoJuegoDetallexIp(query.objeto.ip);
            var tickets = await _ticketRepository.GetTicketSaldoxticket_nro(query.objeto.ticket);
            if(tickets.saldoticketfin == 0)
            {
                nuevo.ip = query.objeto.ip;
                nuevo.saldo = 0;
            }
            else
            {
                int nroJugada = tickets.jugada + 1;
                transacciones registro = new transacciones();
                registro.nroticket = tickets.nroticket;
                registro.caja_id = tickets.caja_id;
                registro.puntojuego_id = puntojuego.id;
                registro.jugada = nroJugada;
                registro.premio = query.objeto.premio;
                registro.importepremio = query.objeto.creditos_ganados;
                registro.estadocobro = false;
                registro.fechahorajugada = DateTime.Now;
                registro.saldoticketini = tickets.saldoticketfin;
                float monto = 0;
                if(query.objeto.premio)
                {
                    monto = tickets.saldoticketfin + query.objeto.creditos_ganados;
                }
                else
                {
                    monto = tickets.saldoticketfin - query.objeto.apuesta;
                }
                registro.saldoticketfin = monto;
                registro.comprobanteventa = tickets.nroticket; ;
                registro.estadopago = false;
                var trans = await _transaccionesRepository.CreateTransaccion(registro);
                if(trans)
                {
                    nuevo.ip = query.objeto.ip;
                    nuevo.saldo = registro.saldoticketfin;
                }
            }
           
            return nuevo;
        }

    }

}
