
using Application.CommandsQueries.Scratch_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.Scratch_CommandsQueries
{
    public class JugadaQueryHandler : IRequestHandler<JugadaQuery, Scratch_jugada>
    {
        private readonly IScratchRepository _scratchRepository;
        private readonly IPuntoJuegoRepository _puntoJuegoRepository;
        public JugadaQueryHandler(IScratchRepository scratchRepository, IPuntoJuegoRepository puntoJuegoRepository)
        {
            _scratchRepository = scratchRepository;
            _puntoJuegoRepository = puntoJuegoRepository;

        }
        public async Task<Scratch_jugada> Handle(JugadaQuery query, CancellationToken cancellationToken)
        {
            if (query.objeto is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }
            Scratch_jugada nuevo = new Scratch_jugada();
            

            return nuevo;
        }

    }

}
