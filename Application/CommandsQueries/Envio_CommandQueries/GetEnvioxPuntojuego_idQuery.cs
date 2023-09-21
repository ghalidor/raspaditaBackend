
using Domain;
using MediatR;

namespace Application.CommandsQueries.Envio_CommandQueries
{
    public class GetEnvioxPuntojuego_idQuery : IRequest<IEnumerable<envio>>
    {
        public Int64 puntoJuego_id { get; set; }
    }
}
