

using Application.CommandsQueries.Rol_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;
using System.Globalization;

namespace Application.Handlers.Rol_CommandsQueries
{
    public class GetRolQueryHandler : IRequestHandler<GetRolQuery, IEnumerable<rol>>
    {
        private readonly IRolRepository _rolRepository;
        public GetRolQueryHandler(IRolRepository rolRepository)
        {
            _rolRepository = rolRepository;
        }
        public async Task<IEnumerable<rol>> Handle(GetRolQuery query, CancellationToken cancellationToken)
        {
            List<rol> lista = new List<rol>();
            var roles = await _rolRepository.GetRol();
            foreach(var item in roles)
            {
                item.fecharegistro_string = item.fecharegistro.ToString() != "01/01/0001 0:00:00" ? item.fecharegistro.ToString("dd-MM-yyyy hh:mm:ss tt", CultureInfo.InvariantCulture) : "----";
                item.estado_string = item.estado ? "ACTIVO" : "INACTIVO";
                item.clase = item.estado ? "success" : "danger";
                lista.Add(item);
            }
            return lista;
        }
    }

}
