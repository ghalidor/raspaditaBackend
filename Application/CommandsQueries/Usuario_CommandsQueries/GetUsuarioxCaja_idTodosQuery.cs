
using Domain;
using MediatR;

namespace Application.CommandsQueries.Usuario_CommandsQueries;
public class GetUsuarioxCaja_idTodosQuery : IRequest<IEnumerable<usuarioCheck>>
{
    public Int64 local_id { get; set; }
    public Int64 caja_id { get; set; }
}
