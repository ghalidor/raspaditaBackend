
using Application.CommandsQueries.Envio_CommandQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.Envio_CommandQueries
{
    public class GetEnvioxPuntojuego_idQueryHandler : IRequestHandler<GetEnvioxPuntojuego_idQuery, IEnumerable<envio>>
    {
        private readonly IEnvioRepository _envioRepository;
        public GetEnvioxPuntojuego_idQueryHandler(IEnvioRepository envioRepository)
        {
            _envioRepository = envioRepository;
        }
        public async Task<IEnumerable<envio>> Handle(GetEnvioxPuntojuego_idQuery query, CancellationToken cancellationToken)
        {
            return await _envioRepository.GetEnvioxPuntojuego_id(query.puntoJuego_id);
        }

    }
}
