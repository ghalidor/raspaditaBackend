
using Application.CommandsQueries.TransaccionesCommandQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.TransaccionesCommandQueries
{
    public class GetTransaccionesxcajaPuntojuego_idQueryHandler : IRequestHandler<GetTransaccionesxcajaPuntojuego_idQuery, IEnumerable<transacciones>>
    {
        private readonly ITransaccionesRepository _transaccionesaRepository;
        public GetTransaccionesxcajaPuntojuego_idQueryHandler(ITransaccionesRepository transaccionesaRepository)
        {
            _transaccionesaRepository = transaccionesaRepository;
        }
        public async Task<IEnumerable<transacciones>> Handle(GetTransaccionesxcajaPuntojuego_idQuery query, CancellationToken cancellationToken)
        {
            return await _transaccionesaRepository.GetTransaccionesxcajaPuntojuego_id(query.caja_id,query.puntoJuego_id);
        }
    }
}
