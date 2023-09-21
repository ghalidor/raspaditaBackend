
using Application.CommandsQueries.TransaccionesCommandQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.TransaccionesCommandQueries
{
    public class GetTransaccionesQueryHandler : IRequestHandler<GetTransaccionesQuery, IEnumerable<transacciones>>
    {
        private readonly ITransaccionesRepository _transaccionesRepository;
        public GetTransaccionesQueryHandler(ITransaccionesRepository transaccionesRepository)
        {
            _transaccionesRepository = transaccionesRepository;
        }
        public async Task<IEnumerable<transacciones>> Handle(GetTransaccionesQuery query, CancellationToken cancellationToken)
        {
            return await _transaccionesRepository.GetTransacciones();
        }
    }
}
