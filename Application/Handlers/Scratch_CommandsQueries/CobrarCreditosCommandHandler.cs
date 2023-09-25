
using Application.CommandsQueries.Scratch_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.Scratch_CommandsQueries
{
    public class CobrarCreditosCommandHandler : IRequestHandler<CobrarCreditosCommand, Scratch_response>
    {
        private readonly IScratchRepository _scratchRepository;
        private readonly IPuntoJuegoRepository _puntoJuegoRepository;
        public CobrarCreditosCommandHandler(IScratchRepository scratchRepository, IPuntoJuegoRepository puntoJuegoRepository)
        {
            _scratchRepository = scratchRepository;
            _puntoJuegoRepository = puntoJuegoRepository;

        }
        public async Task<Scratch_response> Handle(CobrarCreditosCommand query, CancellationToken cancellationToken)
        {
            if (query.ip is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }
            Scratch_response nuevo = new Scratch_response();
            string ip = query.ip;
            string ticket = query.ticket;

            nuevo.response = true;
            return nuevo;
        }
    }

}
