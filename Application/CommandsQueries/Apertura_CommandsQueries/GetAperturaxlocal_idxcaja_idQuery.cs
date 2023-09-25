
using Domain;
using MediatR;

namespace Application.CommandsQueries.Apertura_CommandsQueries
{
    public class GetAperturaxlocal_idxcaja_idQuery : IRequest<IEnumerable<apertura>>
    {
        public Int64 local_id { get; set; }
        public Int64 caja_id { get; set; }
    }
}
