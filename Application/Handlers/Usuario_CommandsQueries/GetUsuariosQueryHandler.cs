
using Application.CommandsQueries.Usuario_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;
using System.Globalization;

namespace Application.Handlers.Usuario_CommandsQueries
{
    public class GetUsuariosQueryHandler : IRequestHandler<GetUsuariosQuery, IEnumerable<usuario>>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public GetUsuariosQueryHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<IEnumerable<usuario>> Handle(GetUsuariosQuery query, CancellationToken cancellationToken)
        {
            List<usuario> lista = new List<usuario>();

            var usuarios = await _usuarioRepository.GetUsuarios();
            foreach(var item in usuarios)
            {
                item.fecharegistro_string = item.fecharegistro.ToString() != "01/01/0001 0:00:00" ? item.fecharegistro.ToString("dd-MM-yyyy hh:mm:ss tt", CultureInfo.InvariantCulture) : "----";
                item.fechaupdated_string = item.fechaupdated.ToString() != "01/01/0001 0:00:00" ? item.fechaupdated.ToString("dd-MM-yyyy hh:mm:ss tt", CultureInfo.InvariantCulture) : "----";
                item.estado_string = item.estado ? "ACTIVO" : "INACTIVO";
                item.clase = item.estado ? "success" : "danger";
                lista.Add(item);
            }
            return lista;
        }
    }
}
