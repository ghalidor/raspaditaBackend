
using Application.CommandsQueries.Caja_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;
using System.Globalization;

namespace Application.Handlers.Caja_CommandsQueries
{
    public class GetCajasQueryHandler : IRequestHandler<GetCajasQuery, IEnumerable<caja>>
    {
        private readonly ICajaRepository _cajaRepository;
        private readonly ILocalRepository _localRepository;
        public GetCajasQueryHandler(ICajaRepository cajaRepository, ILocalRepository localRepository)
        {
            _cajaRepository = cajaRepository;
            _localRepository = localRepository;
        }
        public async Task<IEnumerable<caja>> Handle(GetCajasQuery query, CancellationToken cancellationToken)
        {
            List<caja> lista = new List<caja>();
            IEnumerable<local> local = await _localRepository.GetLocal();
            if(local != null)
            {
                var cajas = await _cajaRepository.GetCaja();
                foreach(var item in cajas)
                {
                    item.fecharegistro_string = item.fecharegistro.ToString() != "01/01/0001 0:00:00" ? item.fecharegistro.ToString("dd-MM-yyyy hh:mm:ss tt", CultureInfo.InvariantCulture) : "----";
                    item.fechaupdated_string = item.fechaupdated.ToString() != "01/01/0001 0:00:00" ? item.fechaupdated.ToString("dd-MM-yyyy hh:mm:ss tt", CultureInfo.InvariantCulture) : "----";
                    item.estado_string = item.estado ? "ACTIVO" : "INACTIVO";
                    item.clase = item.estado ? "success" : "danger";
                    item.local_nombre = local.Where(x=>x.id==item.local_id).Select(z=>z.nombre).FirstOrDefault();
                    lista.Add(item);
                }
            }
            return lista;
        }
    }
}
