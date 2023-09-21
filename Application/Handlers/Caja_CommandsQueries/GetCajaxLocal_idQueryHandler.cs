
using Application.CommandsQueries.Caja_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.Caja_CommandsQueries
{
    public class GetCajaxLocal_idQueryHandler : IRequestHandler<GetCajaxLocal_idQuery,IEnumerable<caja>>
    {
        private readonly ICajaRepository _cajaRepository;
        public GetCajaxLocal_idQueryHandler(ICajaRepository cajaRepository)
        {
            _cajaRepository = cajaRepository;
        }
        public async Task<IEnumerable<caja>> Handle(GetCajaxLocal_idQuery query, CancellationToken cancellationToken)
        {
            return await _cajaRepository.GetCajasxlocal_id(query.local_id);
        }
    }
}
