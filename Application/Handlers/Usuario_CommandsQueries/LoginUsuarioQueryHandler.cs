
using Application.CommandsQueries.Usuario_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.Usuario_CommandsQueries
{
    public class LoginUsuarioQueryHandler : IRequestHandler<LoginUsuarioQuery, usuarioResponse>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public LoginUsuarioQueryHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<usuarioResponse> Handle(LoginUsuarioQuery query, CancellationToken cancellationToken)
        {
            usuarioResponse lista = new usuarioResponse();

            //var usuarios = await _usuarioRepository.GetUsuarioLocal(query.local_id);
            //foreach(var item in usuarios)
            //{
            //    item.fecharegistro_string = item.fecharegistro.ToString() != "01/01/0001 0:00:00" ? item.fecharegistro.ToString("dd-MM-yyyy hh:mm:ss tt", CultureInfo.InvariantCulture) : "----";
            //    item.fechaupdated_string = item.fechaupdated.ToString() != "01/01/0001 0:00:00" ? item.fechaupdated.ToString("dd-MM-yyyy hh:mm:ss tt", CultureInfo.InvariantCulture) : "----";
            //    item.estado_string = item.estado ? "ACTIVO" : "INACTIVO";
            //    item.clase = item.estado ? "success" : "danger";
            //    lista.Add(item);
            //}
            return lista;
        }
    }
}
