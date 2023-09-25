
using Domain;
using MediatR;

namespace Application.CommandsQueries.Scratch_CommandsQueries
{
    public class CobrarCreditosCommand : IRequest<Scratch_response>
    {
        public string ip { get; set; }
        public string ticket { get; set; }
    }

}
