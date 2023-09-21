using Domain;
using MediatR;

namespace Application.CommandsQueries.PuntoJuego_CommandsQueries
{
    public class GetPuntoJuegoQuery : IRequest<IEnumerable<puntojuego>>
    {

    }
}
