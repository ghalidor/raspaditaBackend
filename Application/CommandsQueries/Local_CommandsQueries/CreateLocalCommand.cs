
using Domain;
using MediatR;

namespace Application.CommandsQueries.Local_CommandsQueries
{
    public class CreateLocalCommand : IRequest<ServiceResponse>
    {
        public localNuevo NewLocal { get; set; }
    }
}
