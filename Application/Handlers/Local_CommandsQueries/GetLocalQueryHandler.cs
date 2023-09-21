using Application.CommandsQueries.Local_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.Local_CommandsQueries
{
    public class GetLocalQueryHandler : IRequestHandler<GetLocalQuery, IEnumerable<local>>
    {
        private readonly ILocalRepository _localRepository;
        public GetLocalQueryHandler(ILocalRepository localRepository)
        {
            _localRepository = localRepository;
        }
        public async Task<IEnumerable<local>> Handle(GetLocalQuery query, CancellationToken cancellationToken)
        {
           
            return await _localRepository.GetLocal();
        }
    }
}
