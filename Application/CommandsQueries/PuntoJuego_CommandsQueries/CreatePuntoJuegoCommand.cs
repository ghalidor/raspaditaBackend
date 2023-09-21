using Domain;
using MediatR;

namespace Application.CommandsQueries.PuntoJuego_CommandsQueries
{
    public class CreatePuntoJuegoCommand : IRequest<ServiceResponse>
    {
        public puntojuegoNuevo NewPuntoJuego { get; set; }
    }
}
