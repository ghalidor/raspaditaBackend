
using Domain;
using MediatR;

namespace Application.CommandsQueries.Caja_CommandsQueries
{
    public class GetCajaxLocal_idQuery : IRequest<IEnumerable<caja>>
    {
        public Int64 local_id { get; set; }

    }
}
