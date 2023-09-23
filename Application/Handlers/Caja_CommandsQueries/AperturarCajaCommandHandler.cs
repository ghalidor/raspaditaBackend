
using Application.CommandsQueries.Caja_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.Caja_CommandsQueries
{
    public class AperturarCajaCommandHandler : IRequestHandler<AperturarCajaCommand, ServiceResponse>
    {
        private readonly ICajaRepository _cajaRepository;
        public AperturarCajaCommandHandler(ICajaRepository cajaRepository)
        {
            _cajaRepository = cajaRepository;
        }

        public async Task<ServiceResponse> Handle(AperturarCajaCommand request, CancellationToken cancellationToken)
        {
            //if (request.NewCaja is null)
            //{
            //    throw new ApplicationException("There is a problem in mapper");
            //}
            ServiceResponse response = new ServiceResponse();
            try
            {
                DateTime fechaHoy = DateTime.Now;
                IEnumerable<caja> cajasActivas = await _cajaRepository.GetCajasxlocal_idxfechahoy(1,fechaHoy);
                caja nuevo = new caja();
                if (!cajasActivas.Any())
                {
                    nuevo.estado = 1;
                    nuevo.local_id = 1;
                    nuevo.fechaoperacion = fechaHoy;
                    nuevo.fechaapertura = DateTime.Now;
                    nuevo.nro_apertura = 1;
                    nuevo.usuario_id =1;
                    bool respuesta = await _cajaRepository.CreateCaja(nuevo);
                    response.response = respuesta;
                    if (respuesta)
                    {
                        response.response = true;
                        response.message = "Se Aperturó caja Corréctamente";
                    }
                    else
                    {
                        response.response = false;
                        response.message = "Error , no se pudo aperturar";
                    }
                }
                else
                {
                    int cantidadCajas = cajasActivas.Count();
                    if(cantidadCajas==3)
                    {
                        response.response = false;
                        response.message = "Error , No se puede aperturar mas cajas";
                    }
                    else
                    {
                        cantidadCajas = cantidadCajas + 1;
                        nuevo.estado = 1;
                        nuevo.local_id = 1;
                        nuevo.fechaoperacion = fechaHoy;
                        nuevo.fechaapertura = DateTime.Now;
                        nuevo.nro_apertura = cantidadCajas;
                        nuevo.usuario_id = 1;
                        bool respuesta = await _cajaRepository.CreateCaja(nuevo);
                        response.response = respuesta;
                        if (respuesta)
                        {
                            response.response = true;
                            response.message = "Se Aperturó caja Corréctamente";
                        }
                        else
                        {
                            response.response = false;
                            response.message = "Error , no se pudo aperturar";
                        }
                    }
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
