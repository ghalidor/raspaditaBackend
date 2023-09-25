
using Domain;
using MediatR;

namespace Application.CommandsQueries.Scratch_CommandsQueries
{
    public class NewScratchQuery : IRequest<Scratch_new>
    {
        public string ip { get; set; }
        public Int64 indice { get; set; }
    }

}
