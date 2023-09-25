
using Application.CommandsQueries.Caja_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.Caja_CommandsQueries
{
    public class UpdateCajaCommandHandler : IRequestHandler<UpdateCajaCommand, ServiceResponse>
    {
        private readonly ICajaRepository _cajaRepository;
        public UpdateCajaCommandHandler(ICajaRepository cajaRepository)
        {
            _cajaRepository = cajaRepository;
        }

        public async Task<ServiceResponse> Handle(UpdateCajaCommand request, CancellationToken cancellationToken)
        {
            if(request.EditCaja is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }
            ServiceResponse response = new ServiceResponse();
            try
            {
                caja nuevo = new caja();
                nuevo.id = request.EditCaja.id;
                nuevo.estado = true;
                nuevo.fechaupdated = DateTime.Now;
                nuevo.local_id = request.EditCaja.local_id;
                nuevo.nombre = request.EditCaja.nombre;
                bool respuesta = await _cajaRepository.UpdateCaja(nuevo);
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
