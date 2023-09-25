
using Domain;
using MediatR;

namespace Application.CommandsQueries.PuntoJuego_CommandsQueries
{
    public class GetDetallePuntoJuegoQuery : IRequest<puntojuego>
    {
        public Int64 id { get; set; }
    }
}
