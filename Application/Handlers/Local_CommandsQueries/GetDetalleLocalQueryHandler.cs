
using Application.CommandsQueries.Local_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.Local_CommandsQueries
{
    public class GetDetalleLocalQueryHandler : IRequestHandler<GetDetalleLocalQuery, local>
    {
        private readonly ILocalRepository _localRepository;
        public GetDetalleLocalQueryHandler(ILocalRepository localRepository)
        {
            _localRepository = localRepository;
        }
        public async Task<local> Handle(GetDetalleLocalQuery query, CancellationToken cancellationToken)
        {
            return await _localRepository.GetDetalleLocal(query.local_id);
        }
    }
}
