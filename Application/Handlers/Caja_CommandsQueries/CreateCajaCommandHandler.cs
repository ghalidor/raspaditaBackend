
using Application.CommandsQueries.Caja_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.Caja_CommandsQueries
{
    public class CreateCajaCommandHandler : IRequestHandler<CreateCajaCommand, ServiceResponse>
    {
        private readonly ICajaRepository _cajaRepository;
        public CreateCajaCommandHandler(ICajaRepository cajaRepository)
        {
            _cajaRepository = cajaRepository;
        }

        public async Task<ServiceResponse> Handle(CreateCajaCommand request, CancellationToken cancellationToken)
        {
            if (request.NewCaja is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }
            ServiceResponse response = new ServiceResponse();
            try
            {
                caja nuevo = new caja();
                nuevo.estado = true;
                nuevo.fecharegistro=DateTime.Now;
                nuevo.local_id = request.NewCaja.local_id;
                nuevo.nombre = request.NewCaja.nombre;
                bool respuesta = await _cajaRepository.CreateCaja(nuevo);
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
