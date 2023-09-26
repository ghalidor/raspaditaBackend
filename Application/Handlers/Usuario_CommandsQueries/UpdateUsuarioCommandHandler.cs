
using Application.CommandsQueries.Usuario_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.Usuario_CommandsQueries
{
    public class UpdateUsuarioCommandHandler : IRequestHandler<UpdateUsuarioCommand, ServiceResponse>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UpdateUsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ServiceResponse> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
        {
            if(request.EditUsuario is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }
            ServiceResponse response = new ServiceResponse();
            try
            {
                usuario nuevo = new usuario();
                nuevo.estado = request.EditUsuario.estado;
                nuevo.fechaupdated = DateTime.Now;
                nuevo.nombre = request.EditUsuario.nombre;
                bool respuesta = await _usuarioRepository.UpdateUsuario(nuevo);

                if(respuesta)
                {
                    response.response = true;
                    response.message = "Se registró Corréctamente";
                }
                else
                {
                    response.response = false;
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
