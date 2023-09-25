
using Domain;
using MediatR;

namespace Application.CommandsQueries.PuntoJuego_CommandsQueries
{
    public class UpdatePuntoJuegoCommand : IRequest<ServiceResponse>
    {
        public puntojuegoEditar EditPuntoJuego { get; set; }
    }
}
