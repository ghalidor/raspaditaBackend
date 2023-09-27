
using Application.CommandsQueries.PuntoJuego_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;
using System.Globalization;

namespace Application.Handlers.PuntoJuego_CommandsQueries
{
    public class GetPuntoJuegoxLocal_idQueryHandler : IRequestHandler<GetPuntoJuegoxLocal_idQuery, IEnumerable<puntojuego>>
    {
        private readonly IPuntoJuegoRepository _puntoJuegoRepository;
        private readonly ILocalRepository _localRepository;
        public GetPuntoJuegoxLocal_idQueryHandler(IPuntoJuegoRepository puntoJuegoRepository, ILocalRepository localRepository)
        {
            _puntoJuegoRepository = puntoJuegoRepository;
            _localRepository = localRepository;
        }
        public async Task<IEnumerable<puntojuego>> Handle(GetPuntoJuegoxLocal_idQuery query, CancellationToken cancellationToken)
        {
            List<puntojuego> lista = new List<puntojuego>();
            IEnumerable<local> local = await _localRepository.GetLocal();
            if(local != null)
            {
                var dispositivos = await _puntoJuegoRepository.GetPuntoJuegoxLocal_id(query.local_id);
                foreach(var item in dispositivos)
                {
                    item.fecharegistro_string = item.fecharegistro.ToString("dd-MM-yyyy") != "01-01-0001" ? item.fecharegistro.ToString("dd-MM-yyyy hh:mm:ss tt", CultureInfo.InvariantCulture) : "----";
                    item.fechaupdated_string = item.fechaupdated.ToString("dd-MM-yyyy") != "01-01-0001" ? item.fechaupdated.ToString("dd-MM-yyyy hh:mm:ss tt", CultureInfo.InvariantCulture) : "----";
                    item.estado_string = item.estado ? "ACTIVO" : "INACTIVO";
                    item.clase = item.estado ? "success" : "danger";
                    item.local_nombre = local.Where(x => x.id == item.local_id).Select(z => z.nombre).FirstOrDefault();
                    lista.Add(item);
                }
            }
            return lista;
        }

    }
}
