using Domain;
using MediatR;

namespace Application.CommandsQueries.Local_CommandsQueries
{
    public class GetLocalQuery : IRequest<IEnumerable<local>>
    {
    }
}
