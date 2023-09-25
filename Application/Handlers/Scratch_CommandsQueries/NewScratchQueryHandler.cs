
using Application.CommandsQueries.Scratch_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.Scratch_CommandsQueries
{
    public class NewScratchQueryHandler : IRequestHandler<NewScratchQuery, Scratch_new>
    {
        private readonly IScratchRepository _scratchRepository;
        private readonly IPuntoJuegoRepository _puntoJuegoRepository;
        public NewScratchQueryHandler(IScratchRepository scratchRepository, IPuntoJuegoRepository puntoJuegoRepository)
        {
            _scratchRepository = scratchRepository;
            _puntoJuegoRepository = puntoJuegoRepository;

        }
        public async Task<Scratch_new> Handle(NewScratchQuery query, CancellationToken cancellationToken)
        {
            if (query.ip is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }
            Scratch_new nuevo = new Scratch_new();
            Int64 posicion = query.indice;
            var tp = await _scratchRepository.GetTp();
            var matrix = await _scratchRepository.GetMatrixPosicion(1);
            nuevo.TP = tp.Select(z => z.tp_value).ToArray();
            nuevo.montoPremiado = matrix.montoPremiado;
            nuevo.simPrem = matrix.simPrem;
            nuevo.simbolos = matrix.simbolos;

            return nuevo;
        }

    }
}

