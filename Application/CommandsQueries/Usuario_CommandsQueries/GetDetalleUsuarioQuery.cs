
using Domain;
using MediatR;

namespace Application.CommandsQueries.Usuario_CommandsQueries
{
    public class GetDetalleUsuarioQuery : IRequest<usuario>
    {
        public Int64 id { get; set; }
    }
}
