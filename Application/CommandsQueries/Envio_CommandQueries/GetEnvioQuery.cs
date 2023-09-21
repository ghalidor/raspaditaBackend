using Domain;
using MediatR;

namespace Application.CommandsQueries.Envio_CommandQueries
{
    public class GetEnvioQuery : IRequest<IEnumerable<envio>>
    {
    }
}
