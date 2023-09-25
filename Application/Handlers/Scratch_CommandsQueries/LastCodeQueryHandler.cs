
using Application.CommandsQueries.Scratch_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.Scratch_CommandsQueries
{
    public class LastCodeQueryHandler : IRequestHandler<LastCodeQuery, Scratch_codigo>
    {
        private readonly IScratchRepository _scratchRepository;
        private readonly IPuntoJuegoRepository _puntoJuegoRepository;
        public LastCodeQueryHandler(IScratchRepository scratchRepository, IPuntoJuegoRepository puntoJuegoRepository)
        {
            _scratchRepository = scratchRepository;
            _puntoJuegoRepository = puntoJuegoRepository;

        }
        public async Task<Scratch_codigo> Handle(LastCodeQuery query, CancellationToken cancellationToken)
        {
            Scratch_codigo nuevo = new Scratch_codigo();

            nuevo.codigo = "12345";
            return nuevo;
        }

    }

}
