
using Application.CommandsQueries.Usuario_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;
using Utilitario;


namespace Application.Handlers.Usuario_CommandsQueries
{
    public class LoginUsuarioQueryHandler : IRequestHandler<LoginUsuarioQuery, usuarioResponse>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ICajaRepository _cajaRepository;
        private readonly ILocalRepository _localRepository;
 
        public LoginUsuarioQueryHandler(IUsuarioRepository usuarioRepository,
            ILocalRepository localRepository,ICajaRepository cajaRepository)
        {
            _usuarioRepository = usuarioRepository;
            _cajaRepository = cajaRepository;
            _localRepository = localRepository;
        
        }
        public async Task<usuarioResponse> Handle(LoginUsuarioQuery query, CancellationToken cancellationToken)
        {
            usuarioResponse respuesta = new usuarioResponse();
            
            var usuarios = await _usuarioRepository.GetDetalleUsuarioNombre(query.login.nombre);
            if (usuarios != null)
            {
                if (usuarios.estado)
                {
                    bool compare = EncriptacionPassword.VerifyPassword(query.login.password, usuarios.password);
                    if (compare)
                    {
                        var local = await _localRepository.GetDetalleLocal(usuarios.local_id);
                        var caja = await _cajaRepository.GetDetalleCaja(usuarios.caja_id);

                        respuesta.nombre = usuarios.nombre;
                        respuesta.message = "Bienvenido," + usuarios.nombre;
                        respuesta.response = true;
                        respuesta.caja_id = usuarios.caja_id;
                        respuesta.caja_nombre = usuarios.caja_id == 0?"No asignado":usuarios.caja_nombre;
                        respuesta.local_id = usuarios.local_id;
                        respuesta.local_nombre = usuarios.local_id == 0 ? "No asignado" : usuarios.local_nombre;
                        respuesta.id = usuarios.id;
                        respuesta.message = "Bienvenido " + respuesta.nombre;
                    }
                    else
                    {
                        respuesta.response = false;
                        respuesta.message = "Error Contraseña no coincide ";
                    }
                   
                }
                else {
                    respuesta.response = false;
                    respuesta.message = "Usuario " + respuesta.nombre + " se encuentra Inactivo";
                }
            
            }
            else
            {
                respuesta.response = false;
                respuesta.message = "No se encontro al usuario";
            }
            return respuesta;
        }
    }
}
