

using Application.CommandsQueries.Usuario_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.Usuario_CommandsQueries
{
    public class CreateUsuarioCajaCommandHandler : IRequestHandler<CreateUsuarioCajaCommand, ServiceResponse>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public CreateUsuarioCajaCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ServiceResponse> Handle(CreateUsuarioCajaCommand request, CancellationToken cancellationToken)
        {
            if(request.NewUsuario is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }
            ServiceResponse response = new ServiceResponse();
            try
            {
                var existenombre = await _usuarioRepository.GetDetalleUsuarioCaja(request.NewUsuario.caja_id,request.NewUsuario.usuario_id);
                if(existenombre == null)
                {
                    usuarioCajaNuevo_ caja = new usuarioCajaNuevo_();
                    caja.caja_id=request.NewUsuario.caja_id;
                    caja.fecharegistro=DateTime.Now;
                    caja.usuario_id=request.NewUsuario.usuario_id;
                    caja.estado = true;
                    bool respuesta = await _usuarioRepository.CreateUsuarioCaja(caja);
                    if(respuesta)
                    {
                        response.response = true;
                        response.message = "Se registró Corréctamente";
                    }
                    else
                    {
                        response.response = false;
                        response.message = "Error, no se pudo registrar";
                    }
                    
                }
                else
                {

                    //usuarioCaja caja = new usuarioCaja();
                    //caja.caja_id = request.NewUsuario.caja_id;
                    //caja.usuario_id = request.NewUsuario.usuario_id;
                    //caja.usuariocaja_id = existenombre.id;
                    //bool respuesta = await _usuarioRepository.UpdateUsuarioCaja(caja);
                    bool respuesta = await _usuarioRepository.DelteUsuarioCaja(existenombre.id);
                    if(respuesta)
                    {
                        response.response = true;
                        response.message = "Se registró Corréctamente";
                    }
                    else
                    {
                        response.response = false;
                        response.message = "Error, no se pudo registrar";
                    }

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
