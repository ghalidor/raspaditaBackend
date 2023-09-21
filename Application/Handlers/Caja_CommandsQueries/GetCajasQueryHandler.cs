using Application.CommandsQueries.Caja_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.Caja_CommandsQueries
{
    public class GetCajasQueryHandler : IRequestHandler<GetCajasQuery, IEnumerable<caja>>
    {
        private readonly ICajaRepository _cajaRepository;
        public GetCajasQueryHandler(ICajaRepository cajaRepository)
        {
            _cajaRepository = cajaRepository;
        }
        public async Task<IEnumerable<caja>> Handle(GetCajasQuery query, CancellationToken cancellationToken)
        {
            return await _cajaRepository.GetCajas();
        }
    }
}
