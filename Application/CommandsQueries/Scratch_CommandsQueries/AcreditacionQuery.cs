using Domain;
using MediatR;

namespace Application.CommandsQueries.Scratch_CommandsQueries
{
    public class AcreditacionQuery : IRequest<Scratch_monto>
    {
        public string ip { get; set; }
        public string ticket { get; set; }
    }
}

