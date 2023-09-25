using Domain;
using MediatR;

namespace Application.CommandsQueries.Caja_CommandsQueries
{
    public class GetDetalleCajaQuery : IRequest<caja>
    {
        public Int64 id { get; set; }
    }
}
