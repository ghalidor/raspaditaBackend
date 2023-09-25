
using Domain;
using MediatR;

namespace Application.CommandsQueries.Rol_CommandsQueries
{
    public class GetDetalleRolQuery : IRequest<rol>
    {
        public Int64 id { get; set; }
    }

}
