
using Application.CommandsQueries.Ticket_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.Ticket_CommandsQueries
{
    public class PagarSaldoTicketCommandHandler : IRequestHandler<PagarSaldoTicketCommand, ServiceResponseTicket>
    {
        private readonly ICajaRepository _cajaRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly ITransaccionesRepository _transaccionesRepository;
        public PagarSaldoTicketCommandHandler(ICajaRepository cajaRepository,
           ITicketRepository ticketRepository, ITransaccionesRepository transaccionesRepository)
        {
            _cajaRepository = cajaRepository;
            _ticketRepository = ticketRepository;
            _transaccionesRepository = transaccionesRepository;
        }

        public async Task<ServiceResponseTicket> Handle(PagarSaldoTicketCommand request, CancellationToken cancellationToken)
        {
            if(request.nroticket is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }
            ServiceResponseTicket response = new ServiceResponseTicket();
            try
            {
                var ticket = await _ticketRepository.GetTicketxnroticket(request.nroticket);
                if (ticket.estado)
                {
                    var saldoticket = await _ticketRepository.GetTicketSaldoxticket_id(ticket.id);

                    transacciones registro = new transacciones();
                    createticketPago nuevo = new createticketPago();
                    nuevo.usuario_id = 1;
                    nuevo.caja_id = request.caja_id;
                    nuevo.ticket_id = ticket.id;
                    nuevo.monto = saldoticket.saldoticketfin;
                    nuevo.fecharegistro = DateTime.Now;
                    Int64 id = await _ticketRepository.Createticketpago(nuevo);

                    if (id > 0)
                    {
                        string nro = id.ToString().PadLeft(11, '0');
                        await _ticketRepository.UpdateTicketPago_nro(id, nro);
                        ticketCreado nuevoticket = new ticketCreado();
                        var detalle = await _ticketRepository.GetTicketPagoxid(id);
                        nuevoticket.nroticket = detalle.nroticket;
                        nuevoticket.credito = (int)detalle.monto;
                        nuevoticket.id = id;
                        nuevoticket.monto = detalle.monto;

                        ticket ticketestado = new ticket();
                        ticketestado.estado = false;
                        ticketestado.id = ticket.id;
                        bool cambiar = await _ticketRepository.UpdateTicketEstado(ticketestado);

                        registro.estadocobro = true;
                        registro.comprobantepagonro = nro;
                        registro.fechacobro = DateTime.Now;
                        registro.estadopago = true;
                        registro.id = saldoticket.transaccion_id;
                        var trans = await _transaccionesRepository.UpdateTransaccionPago(registro);

                        response.ticket = nuevoticket;
                        response.response = true;
                        response.message = "Se registró Corréctamente";
                    }
                    else
                    {
                        response.message = "Error , no se pudo registrar";
                    }
                }
                else
                {
                    var ticket_caja = await _ticketRepository.GetTicketPagoxticket_id(ticket.id);
                    var caja = await _cajaRepository.GetDetalleCaja(ticket_caja.caja_id);

                    response.response = false;
                    response.message = "Ticket ya Pagado en "+caja.nombre;
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
