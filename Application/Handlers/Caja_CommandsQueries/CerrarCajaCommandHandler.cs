
using Application.CommandsQueries.Caja_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.Caja_CommandsQueries
{
    public class CerrarCajaCommandhandler : IRequestHandler<CerrarCajaCommand, ServiceResponse>
    {
        private readonly ICajaRepository _cajaRepository;
        public CerrarCajaCommandhandler(ICajaRepository cajaRepository)
        {
            _cajaRepository = cajaRepository;
        }

        public async Task<ServiceResponse> Handle(CerrarCajaCommand request, CancellationToken cancellationToken)
        {
            if (request.id ==0)
            {
                throw new ApplicationException("There is a problem in mapper");
            }
            ServiceResponse response = new ServiceResponse();
            try
            {
                caja nuevo = new caja();
                nuevo.estado = 1;
                nuevo.fechacierre = DateTime.Now;
                nuevo.usuario_id = 0;
                bool respuesta = await _cajaRepository.CreateCaja(nuevo);
                response.response = respuesta;
                if (respuesta)
                {
                    response.message = "Se Cerró Corréctamente";
                }
                else
                {
                    response.message = "Error , no se pudo Cerrar";
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
