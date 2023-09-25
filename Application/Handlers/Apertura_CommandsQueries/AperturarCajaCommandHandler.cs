
using Application.CommandsQueries.Apertura_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.Apertura_CommandsQueries
{
    public class AperturarCajaCommandHandler : IRequestHandler<AperturarCajaCommand, ServiceResponse>
    {
        private readonly IAperturaRepository _aperturaRepository;
        private readonly ICajaRepository _cajaRepository;
        public AperturarCajaCommandHandler(IAperturaRepository aperturaRepository,
            ICajaRepository cajaRepository)
        {
            _aperturaRepository = aperturaRepository;
            _cajaRepository = cajaRepository;
        }

        public async Task<ServiceResponse> Handle(AperturarCajaCommand request, CancellationToken cancellationToken)
        {
            if(request.local_id ==0)
            {
                throw new ApplicationException("There is a problem in mapper");
            }
            if(request.caja_id == 0)
            {
                throw new ApplicationException("There is a problem in mapper");
            }
            ServiceResponse response = new ServiceResponse();
            try
            {
                DateTime fechaHoy = DateTime.Now;
                caja cajaDetalle = await _cajaRepository.GetDetalleCaja(request.caja_id);
                IEnumerable<apertura> aperturasActivas = await _aperturaRepository.GetAperturaxlocal_idxfechahoy(request.local_id,request.caja_id,fechaHoy);
                apertura nuevo = new apertura();
                if(!aperturasActivas.Any())
                {
                    nuevo.estado = 1;
                    nuevo.local_id = request.local_id;
                    nuevo.caja_id = request.caja_id;
                    nuevo.fechaoperacion = fechaHoy;
                    nuevo.fechaapertura = DateTime.Now;
                    nuevo.nro_apertura = 1;
                    nuevo.usuario_id = 1;
                    bool respuesta = await _aperturaRepository.CreateApertura(nuevo);
                    response.response = respuesta;
                    if(respuesta)
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
                    int cantidadCajas = aperturasActivas.Count();
                    if(cantidadCajas == 3)
                    {
                        response.response = false;
                        response.message = "Error , No se puede aperturar ,Ya existen 3 aperturas en la caja "+ cajaDetalle.nombre;
                    }
                    else
                    {
                        int activas = aperturasActivas.Where(z=>z.estado==1).Count();
                        if(activas > 0){
                            response.response = false;
                            response.message = "Error , No se puede aperturar ,hay un registro de apertura abierto en la caja" + cajaDetalle.nombre;
                        }
                        else
                        {
                            cantidadCajas = cantidadCajas + 1;
                            nuevo.estado = 1;
                            nuevo.local_id = request.local_id;
                            nuevo.caja_id = request.caja_id;
                            nuevo.fechaoperacion = fechaHoy;
                            nuevo.fechaapertura = DateTime.Now;
                            nuevo.nro_apertura = cantidadCajas;
                            nuevo.usuario_id = 1;
                            bool respuesta = await _aperturaRepository.CreateApertura(nuevo);
                            response.response = respuesta;
                            if(respuesta)
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
