
using Domain;
using MediatR;

namespace Application.CommandsQueries.Local_CommandsQueries
{
    public class GetDetalleLocalQuery : IRequest<local>
    {
        public Int64 local_id { get; set; }
    }

}
