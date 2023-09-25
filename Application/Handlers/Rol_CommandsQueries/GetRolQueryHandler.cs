

using Application.CommandsQueries.Rol_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.Rol_CommandsQueries
{
    public class GetRolQueryHandler : IRequestHandler<GetRolQuery, IEnumerable<rol>>
    {
        private readonly IRolRepository _rolRepository;
        public GetRolQueryHandler(IRolRepository rolRepository)
        {
            _rolRepository = rolRepository;
        }
        public async Task<IEnumerable<rol>> Handle(GetRolQuery query, CancellationToken cancellationToken)
        {
            return await _rolRepository.GetRol();
        }
    }

}
