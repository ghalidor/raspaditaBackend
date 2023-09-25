using Application.CommandsQueries.PuntoJuego_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.PuntoJuego_CommandsQueries
{
    public class UpdatePuntoJuegoCommandHandler : IRequestHandler<UpdatePuntoJuegoCommand, ServiceResponse>
    {
        private readonly IPuntoJuegoRepository _puntoJuegoRepository;
        public UpdatePuntoJuegoCommandHandler(IPuntoJuegoRepository puntoJuegoRepository)
        {
            _puntoJuegoRepository = puntoJuegoRepository;
        }

        public async Task<ServiceResponse> Handle(UpdatePuntoJuegoCommand request, CancellationToken cancellationToken)
        {
            if(request.EditPuntoJuego is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }
            ServiceResponse response = new ServiceResponse();
            try
            {
                puntojuego nuevo = new puntojuego();
                nuevo.id = request.EditPuntoJuego.id;
                nuevo.estado = request.EditPuntoJuego.estado;
                nuevo.local_id = request.EditPuntoJuego.local_id;
                nuevo.nro_punto = request.EditPuntoJuego.nro_punto;
                nuevo.ip = request.EditPuntoJuego.ip;
                nuevo.fechaupdated = DateTime.Now;
                bool respuesta = await _puntoJuegoRepository.UpdatePuntoJuego(nuevo);
                response.response = respuesta;
                if(respuesta)
                {
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
