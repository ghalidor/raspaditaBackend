
using Application.CommandsQueries.PuntoJuego_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.PuntoJuego_CommandsQueries
{
    public class GetDetallePuntoJuegoQueryHandler : IRequestHandler<GetDetallePuntoJuegoQuery, puntojuego>
    {
        private readonly IPuntoJuegoRepository _puntoJuegoRepository;
        public GetDetallePuntoJuegoQueryHandler(IPuntoJuegoRepository puntoJuegoRepository)
        {
            _puntoJuegoRepository = puntoJuegoRepository;
        }
        public async Task<puntojuego> Handle(GetDetallePuntoJuegoQuery query, CancellationToken cancellationToken)
        {
            return await _puntoJuegoRepository.GetPuntoJuegoDetalle(query.id);
        }
    }
}
