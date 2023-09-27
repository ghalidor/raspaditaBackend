using Application.CommandsQueries.Local_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;
using System.Globalization;

namespace Application.Handlers.Local_CommandsQueries
{
    public class GetLocalQueryHandler : IRequestHandler<GetLocalQuery, IEnumerable<local>>
    {
        private readonly ILocalRepository _localRepository;
        public GetLocalQueryHandler(ILocalRepository localRepository)
        {
            _localRepository = localRepository;
        }
        public async Task<IEnumerable<local>> Handle(GetLocalQuery query, CancellationToken cancellationToken)
        {
            List<local> lista = new List<local>();
            var local = await _localRepository.GetLocal();
            foreach (var item in local)
            {
                item.fecharegistro_string = item.fecharegistro.ToString("dd-MM-yyyy") != "01-01-0001" ? item.fecharegistro.ToString("dd-MM-yyyy hh:mm:ss tt", CultureInfo.InvariantCulture) : "----";
                item.estado_string = item.estado == true ? "ACTIVO" :"INACTIVO";
                item.clase = item.estado ? "success" : "danger";
                lista.Add(item);
            }

            return lista;
        }
    }
}
