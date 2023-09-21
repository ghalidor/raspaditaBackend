
using Application.CommandsQueries.PuntoJuego_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.PuntoJuego_CommandsQueries
{
    public class GetPuntoJuegoQueryHandler : IRequestHandler<GetPuntoJuegoQuery, IEnumerable<puntojuego>>
    {
        private readonly IPuntoJuegoRepository _puntoJuegoRepository;
        public GetPuntoJuegoQueryHandler(IPuntoJuegoRepository puntoJuegoRepository)
        {
            _puntoJuegoRepository = puntoJuegoRepository;
        }
        public async Task<IEnumerable<puntojuego>> Handle(GetPuntoJuegoQuery query, CancellationToken cancellationToken)
        {
            return await _puntoJuegoRepository.GetPuntojuego();
        }
    }
}
