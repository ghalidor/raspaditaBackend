
using Application.CommandsQueries.TransaccionesCommandQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.TransaccionesCommandQueries
{
    public class CreateTransaccionCommandHandler : IRequestHandler<CreateTransaccionCommand, ServiceResponse>
    {
        private readonly ITransaccionesRepository _transaccionesRepository;
        public CreateTransaccionCommandHandler(ITransaccionesRepository transaccionesRepository)
        {
            _transaccionesRepository = transaccionesRepository;
        }

        public async Task<ServiceResponse> Handle(CreateTransaccionCommand request, CancellationToken cancellationToken)
        {
            if (request.NewTransacciones is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }
            ServiceResponse response = new ServiceResponse();
            try
            {
                transacciones nuevo = new transacciones();
                nuevo.fechahorajugada = DateTime.Now;
                nuevo.caja_id = request.NewTransacciones.caja_id;
                nuevo.puntojuego_id = request.NewTransacciones.puntojuego_id;
                nuevo.jugada = request.NewTransacciones.jugada;

                nuevo.premio = request.NewTransacciones.premio;
                nuevo.importepremio = request.NewTransacciones.importepremio;
                nuevo.nroticket = request.NewTransacciones.nroticket;

                bool respuesta = await _transaccionesRepository.CreateTransaccion(nuevo);
                response.response = respuesta;
                if (respuesta)
                {
                    response.message = "Se registró Corréctamente";
                }
                else
                {
                    response.message = "Error , no se pudo registrar";
                }
            }
            catch (Exception exp)
            {
                response.response = false;
                response.message = "Error ," + exp.Message;
            }

            return response;
        }
    }
}
