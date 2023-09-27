
using Application.CommandsQueries.Caja_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;
using System.Globalization;

namespace Application.Handlers.Caja_CommandsQueries
{
    public class GetCajaxLocal_idQueryHandler : IRequestHandler<GetCajaxLocal_idQuery,IEnumerable<caja>>
    {
        private readonly ICajaRepository _cajaRepository;
        private readonly ILocalRepository _localRepository;
        public GetCajaxLocal_idQueryHandler(ICajaRepository cajaRepository, ILocalRepository localRepository)
        {
            _cajaRepository = cajaRepository;
            _localRepository = localRepository;
        }
        public async Task<IEnumerable<caja>> Handle(GetCajaxLocal_idQuery query, CancellationToken cancellationToken)
        {
            List<caja> lista = new List<caja>();
            local local = await _localRepository.GetDetalleLocal(query.local_id);
            if(local != null)
            {
                var cajas = await _cajaRepository.GetCajaxlocal_id(query.local_id);
                foreach(var item in cajas)
                {
                    item.fecharegistro_string = item.fecharegistro.ToString("dd-MM-yyyy") != "01-01-0001" ? item.fecharegistro.ToString("dd-MM-yyyy hh:mm:ss tt", CultureInfo.InvariantCulture) : "----";
                    item.fechaupdated_string = item.fechaupdated.ToString("dd-MM-yyyy") != "01-01-0001" ? item.fechaupdated.ToString("dd-MM-yyyy hh:mm:ss tt", CultureInfo.InvariantCulture) : "----";
                    item.estado_string = item.estado?"ACTIVO":"INACTIVO";
                    item.clase = item.estado ? "success" : "danger";
                    item.local_nombre = local.nombre;
                    lista.Add(item);
                }
            }
            return lista;
        }
    }
}
