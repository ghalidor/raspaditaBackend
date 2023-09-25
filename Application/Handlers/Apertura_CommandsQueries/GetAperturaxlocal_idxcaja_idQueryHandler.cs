﻿
using Application.CommandsQueries.Apertura_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;
using System.Globalization;

namespace Application.Handlers.Apertura_CommandsQueries
{
    public class GetAperturaxlocal_idxcaja_idQueryHandler : IRequestHandler<GetAperturaxlocal_idxcaja_idQuery, IEnumerable<apertura>>
    {
        private readonly IAperturaRepository _aperturaRepository;
        private readonly ILocalRepository _localRepository;
        private readonly ICajaRepository _cajaRepository;
        public GetAperturaxlocal_idxcaja_idQueryHandler(
            IAperturaRepository aperturaRepository,
            ICajaRepository cajaRepository,
            ILocalRepository localRepository)
        {
            _aperturaRepository = aperturaRepository;
            _cajaRepository = cajaRepository;
            _localRepository = localRepository;
        }

        public async Task<IEnumerable<apertura>> Handle(GetAperturaxlocal_idxcaja_idQuery request, CancellationToken cancellationToken)
        {
            if(request.local_id == 0)
            {
                throw new ApplicationException("There is a problem in mapper");
            }
            if(request.caja_id == 0)
            {
                throw new ApplicationException("There is a problem in mapper");
            }
            DateTime fechahoy=DateTime.Now;
            List<apertura> lista = new List<apertura>();
            local localdetalle = await _localRepository.GetDetalleLocal(request.local_id);
            caja cajadetalle = await _cajaRepository.GetDetalleCaja(request.caja_id);
            if(localdetalle != null)
            {
                var aperturas = await _aperturaRepository.GetAperturaxlocal_idxfechahoy(request.local_id, request.caja_id, fechahoy);
                foreach(var item in aperturas)
                {
                    item.fechaoperacion_string = item.fechaoperacion.ToString() != "01/01/0001 0:00:00" ? item.fechaoperacion.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture) : "----";
                    item.fechaapertura_string = item.fechaapertura.ToString() != "01/01/0001 0:00:00" ? item.fechaapertura.ToString("dd-MM-yyyy hh:mm:ss tt", CultureInfo.InvariantCulture) : "----";
                    item.fechacierre_string = item.fechacierre.ToString() != "01/01/0001 0:00:00" ? item.fechacierre.ToString("dd-MM-yyyy hh:mm:ss tt", CultureInfo.InvariantCulture) : "----";                  
                    item.usuario_nombre = "prueba";
                    item.estado_string = item.estado == 1 ? "ABIERTO" : item.estado == 2 ? "CERRADO" : "ANULADO";
                    item.clase = item.estado ==1? "success" : "danger";
                    item.local_nombre = localdetalle.nombre;
                    item.caja_nombre = cajadetalle.nombre;
                    lista.Add(item);
                }
            }
            return lista;
        }
    }
}
