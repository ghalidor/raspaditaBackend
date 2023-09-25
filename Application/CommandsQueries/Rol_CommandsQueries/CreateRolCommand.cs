
using Domain;
using MediatR;

namespace Application.CommandsQueries.Rol_CommandsQueries
{
    public class CreateRolCommand : IRequest<ServiceResponse>
    {
        public rolNuevo NewRol { get; set; }

    }

}
