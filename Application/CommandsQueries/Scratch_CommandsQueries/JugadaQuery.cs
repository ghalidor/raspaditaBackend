
using Domain;
using MediatR;

namespace Application.CommandsQueries.Scratch_CommandsQueries
{
    public class JugadaQuery : IRequest<Scratch_jugada>
    {
        public Scratch_jugadaobjeto objeto { get; set; }
    }
}

