
using Application.CommandsQueries.Caja_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.Caja_CommandsQueries
{
    public class GetDetalleCajaQueryHandler : IRequestHandler<GetDetalleCajaQuery, caja>
    {
        private readonly ICajaRepository _cajaRepository;
        private readonly ILocalRepository _localRepository;
        public GetDetalleCajaQueryHandler(ICajaRepository cajaRepository, ILocalRepository localRepository)
        {
            _cajaRepository = cajaRepository;
            _localRepository = localRepository;
        }
        public async Task<caja> Handle(GetDetalleCajaQuery query, CancellationToken cancellationToken)
        {
            return await _cajaRepository.GetDetalleCaja(query.id);
        }
    }
}
