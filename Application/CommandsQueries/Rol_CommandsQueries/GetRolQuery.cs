
using Domain;
using MediatR;

namespace Application.CommandsQueries.Rol_CommandsQueries
{
    public class GetRolQuery : IRequest<IEnumerable<rol>>
    {
    }

}
