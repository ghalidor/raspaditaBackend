using Domain;
using MediatR;

namespace Application.CommandsQueries.Caja_CommandsQueries
{
    public class CerrarCajaCommand : IRequest<ServiceResponse>
    {
        public Int64 id { get; set; }
    }
}
