
using Domain;
using MediatR;

namespace Application.CommandsQueries.TransaccionesCommandQueries
{
    public class GetTransaccionesxcajaPuntojuego_idQuery : IRequest<IEnumerable<transacciones>>
    {
        public int puntoJuego_id { get; set; }
        public Int64 caja_id { get; set; }
    }
}
