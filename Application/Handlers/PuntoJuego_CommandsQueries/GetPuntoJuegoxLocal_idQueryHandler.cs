
using Application.CommandsQueries.PuntoJuego_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.PuntoJuego_CommandsQueries
{
    public class GetPuntoJuegoxLocal_idQueryHandler : IRequestHandler<GetPuntoJuegoxLocal_idQuery, IEnumerable<puntojuego>>
    {
        private readonly IPuntoJuegoRepository _puntoJuegoRepository;
        public GetPuntoJuegoxLocal_idQueryHandler(IPuntoJuegoRepository puntoJuegoRepository)
        {
            _puntoJuegoRepository = puntoJuegoRepository;
        }
        public async Task<IEnumerable<puntojuego>> Handle(GetPuntoJuegoxLocal_idQuery query, CancellationToken cancellationToken)
        {
            return await _puntoJuegoRepository.GetPuntoJuegoxLocal_id(query.local_id);
        }

    }
}
