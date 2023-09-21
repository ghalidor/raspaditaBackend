
using Domain;
using MediatR;

namespace Application.CommandsQueries.PuntoJuego_CommandsQueries
{
    public class GetPuntoJuegoxLocal_idQuery : IRequest<IEnumerable<puntojuego>>
    {
        public Int64 local_id { get; set; }

    }
}
