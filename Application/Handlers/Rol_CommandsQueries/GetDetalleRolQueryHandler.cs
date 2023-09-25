
using Application.CommandsQueries.Rol_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.Rol_CommandsQueries
{
    public class GetDetalleRolQueryHandler : IRequestHandler<GetDetalleRolQuery, rol>
    {
        private readonly IRolRepository _rolRepository;
        public GetDetalleRolQueryHandler(IRolRepository rolRepository)
        {
            _rolRepository = rolRepository;
        }
        public async Task<rol> Handle(GetDetalleRolQuery query, CancellationToken cancellationToken)
        {
            return await _rolRepository.GetDetalleRol(query.id);
        }
    }

}
