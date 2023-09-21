using Domain;
using MediatR;

namespace Application.CommandsQueries.Caja_CommandsQueries
{
    public class GetCajasQuery : IRequest<IEnumerable<caja>>
    {

    }
}
