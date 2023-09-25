using Domain;
using MediatR;

namespace Application.CommandsQueries.Apertura_CommandsQueries
{
    public class AperturarCajaCommand : IRequest<ServiceResponse>
    {
        public Int64 local_id { get; set; }
        public Int64 caja_id { get; set; }
    }
}
