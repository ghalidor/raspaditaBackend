
using Application.CommandsQueries.Usuario_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.Usuario_CommandsQueries
{
    public class CreateUsuarioCommandHandler : IRequestHandler<CreateUsuarioCommand, ServiceResponse>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public CreateUsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ServiceResponse> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            if(request.NewUsuario is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }
            ServiceResponse response = new ServiceResponse();
            try
            {
                usuario nuevo = new usuario();
                nuevo.estado = true;
                nuevo.fecharegistro = DateTime.Now;
                nuevo.password = request.NewUsuario.password;
                nuevo.nombre = request.NewUsuario.nombre;
                Int64 id = await _usuarioRepository.CreateUsuario(nuevo);

                usuarioRol usuarioRol = new usuarioRol();
                usuarioRol.usuario_id = id;
                usuarioRol.rol_id = request.NewUsuario.rol_id;
                usuarioRol.fecharegistro = DateTime.Now;
                var rolusuario = await _usuarioRepository.CreateUsuarioRol(usuarioRol);

                usuarioLocal usuariolocal = new usuarioLocal();
                usuariolocal.local_id = request.NewUsuario.local_id;
                usuariolocal.rol_id = request.NewUsuario.rol_id;
                usuariolocal.usuario_id = id;
                usuariolocal.fecharegistro = DateTime.Now;
                var localusuario = await _usuarioRepository.CreateUsuarioLocal(usuariolocal);
                if(id>0)
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
