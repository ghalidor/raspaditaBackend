
using Domain;
using MediatR;

namespace Application.CommandsQueries.Local_CommandsQueries
{
    public class UpdateLocalCommand : IRequest<ServiceResponse>
    {
        public localEditar EditLocal { get; set; }
    }
}
