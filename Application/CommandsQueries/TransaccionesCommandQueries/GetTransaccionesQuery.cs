using Domain;
using MediatR;

namespace Application.CommandsQueries.TransaccionesCommandQueries
{
    public class GetTransaccionesQuery : IRequest<IEnumerable<transacciones>>
    {

    }
}
