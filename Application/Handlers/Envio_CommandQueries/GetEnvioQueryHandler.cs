
using Application.CommandsQueries.Envio_CommandQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.Envio_CommandQueries
{
    public class GetEnvioQueryHandler : IRequestHandler<GetEnvioQuery, IEnumerable<envio>>
    {
        private readonly IEnvioRepository _envioRepository;
        public GetEnvioQueryHandler(IEnvioRepository envioRepository)
        {
            _envioRepository = envioRepository;
        }
        public async Task<IEnumerable<envio>> Handle(GetEnvioQuery query, CancellationToken cancellationToken)
        {
            return await _envioRepository.GetEnvio();
        }
    }
}
