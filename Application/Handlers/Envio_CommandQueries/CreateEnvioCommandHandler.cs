
using Application.CommandsQueries.Envio_CommandQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.Envio_CommandQueries
{
    public class CreateEnvioCommandHandler : IRequestHandler<CreateEnvioCommand, ServiceResponse>
    {
        private readonly IEnvioRepository _envioRepository;
        public CreateEnvioCommandHandler(IEnvioRepository envioRepository)
        {
            _envioRepository = envioRepository;
        }

        public async Task<ServiceResponse> Handle(CreateEnvioCommand request, CancellationToken cancellationToken)
        {
            if (request.NewEnvio is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }
            ServiceResponse response = new ServiceResponse();
            try
            {
                envio nuevo = new envio();
                nuevo.estado = true;
                nuevo.nroticket = request.NewEnvio.nroticket;
                nuevo.puntojuego_id = request.NewEnvio.puntojuego_id;
                nuevo.credito = request.NewEnvio.credito;
                nuevo.fecharegistro = DateTime.Now;
                bool respuesta = await _envioRepository.CreateEnvio(nuevo);
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
