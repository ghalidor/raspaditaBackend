
using Application.CommandsQueries.Ticket_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.Ticket_CommandsQueries
{
    public class GenerarTicketCommandHandler : IRequestHandler<GenerarTicketCommand, ServiceResponseTicket>
    {
        private readonly ICajaRepository _cajaRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly ITransaccionesRepository _transaccionesRepository;
        private readonly IAperturaRepository _aperturaRepository;
        public GenerarTicketCommandHandler(ICajaRepository cajaRepository,
           ITicketRepository ticketRepository, ITransaccionesRepository transaccionesRepository, IAperturaRepository aperturaRepository)
        {
            _cajaRepository = cajaRepository;
            _ticketRepository = ticketRepository;
            _transaccionesRepository = transaccionesRepository;
            _aperturaRepository = aperturaRepository;
        }

        public async Task<ServiceResponseTicket> Handle(GenerarTicketCommand request, CancellationToken cancellationToken)
        {
            if(request.NewTicket is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }
            ServiceResponseTicket response = new ServiceResponseTicket();
            try
            {
                DateTime hoy = DateTime.Now;
                Int64 local_id = 0;

                var caja = await _cajaRepository.GetDetalleCaja(request.NewTicket.caja_id);

                var aperturalista = await _aperturaRepository.GetAperturaxlocal_idxfechahoy(caja.local_id, request.NewTicket.caja_id, hoy);

                if(!aperturalista.Any())
                {
                    response.response = false;
                    response.message = "No hay aperturas Activas";
                    return response;
                }
                apertura aperturadetalle = aperturalista.Where(x => x.estado == 1).FirstOrDefault();
                if(aperturadetalle == null)
                {
                    response.response = false;
                    response.message = "No hay aperturas Activas";
                    return response;
                }

                transacciones registro =new transacciones();
                ticket nuevo = new ticket();
                nuevo.estado = true;
                nuevo.fecharegistro = DateTime.Now;
                nuevo.puntojuego_id = request.NewTicket.puntojuego_id;
                nuevo.monto = request.NewTicket.monto;
                nuevo.credito=request.NewTicket.credito;
                nuevo.apertura_id = aperturadetalle.id;
                Int64 id = await _ticketRepository.CreateTicket(nuevo);
               
                if(id>0)
                {
                    string nro = id.ToString().PadLeft(11, '0');
                    await _ticketRepository.UpdateTicket_nro(id,nro);
                    ticketCreado nuevoticket = new ticketCreado();
                    var detalle =  await _ticketRepository.GetTicketxid(id);
                    nuevoticket.nroticket = detalle.nroticket;
                    nuevoticket.credito = detalle.credito;
                    nuevoticket.id = id;
                    nuevoticket.monto = detalle.monto;


                    
                    registro.nroticket = nro;
                    registro.caja_id = request.NewTicket.caja_id;
                    registro.puntojuego_id=request.NewTicket.puntojuego_id;
                    registro.jugada = 1;
                    registro.premio = false;
                    registro.importepremio = 0;
                    registro.estadocobro = false;
                    registro.fechahorajugada = DateTime.Now;
                    registro.saldoticketini = request.NewTicket.monto;
                    registro.saldoticketfin = request.NewTicket.monto;
                    registro.comprobanteventa = nro;
                    registro.estadopago = false;
                    var trans = await _transaccionesRepository.CreateTransaccion(registro);


                    response.ticket = nuevoticket;
                    response.response = true;
                    response.message = "Se registró Corréctamente";
                }
                else
                {
                    response.message = "Error , no se pudo registrar";
                }
            }
            catch(Exception exp)
            {
                response.response = false;
                response.message = "Error ," + exp.Message;
            }

            return response;
        }
    }
}
