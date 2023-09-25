
using Application.CommandsQueries.Scratch_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.Scratch_CommandsQueries
{
    public class AcreditacionQueryHandler : IRequestHandler<AcreditacionQuery, Scratch_monto>
    {
        private readonly IScratchRepository _scratchRepository;
        private readonly IPuntoJuegoRepository _puntoJuegoRepository;
        public AcreditacionQueryHandler(IScratchRepository scratchRepository, IPuntoJuegoRepository puntoJuegoRepository)
        {
            _scratchRepository = scratchRepository;
            _puntoJuegoRepository = puntoJuegoRepository;

        }
        public async Task<Scratch_monto> Handle(AcreditacionQuery query, CancellationToken cancellationToken)
        {
            if (query.ip is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }
            Scratch_monto nuevo = new Scratch_monto();
            string ip = query.ip;
            string ticket = query.ticket;

            nuevo.monto = 32;
            return nuevo;
        }
    }
}

