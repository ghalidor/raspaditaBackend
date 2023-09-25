
using Domain;
using MediatR;

namespace Application.CommandsQueries.Rol_CommandsQueries
{
    public class UpdateRolCommand : IRequest<ServiceResponse>
    {
        public rolEditar EditRol { get; set; }

    }

}
