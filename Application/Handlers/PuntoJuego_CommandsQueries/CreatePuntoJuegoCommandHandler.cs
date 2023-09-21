
using Application.CommandsQueries.PuntoJuego_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.PuntoJuego_CommandsQueries
{
    public class CreatePuntoJuegoCommandHandler : IRequestHandler<CreatePuntoJuegoCommand, ServiceResponse>
    {
        private readonly IPuntoJuegoRepository _puntoJuegoRepository;
        public CreatePuntoJuegoCommandHandler(IPuntoJuegoRepository puntoJuegoRepository)
        {
            _puntoJuegoRepository = puntoJuegoRepository;
        }

        public async Task<ServiceResponse> Handle(CreatePuntoJuegoCommand request, CancellationToken cancellationToken)
        {
            if (request.NewPuntoJuego is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }
            ServiceResponse response = new ServiceResponse();
            try
            {
                puntojuego nuevo = new puntojuego();
                nuevo.estado = true;
                nuevo.local_id = request.NewPuntoJuego.local_id;
                nuevo.nro_punto = request.NewPuntoJuego.nro_punto;
                nuevo.ip = request.NewPuntoJuego.ip;
                bool respuesta = await _puntoJuegoRepository.CreatePuntoJuego(nuevo);
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
