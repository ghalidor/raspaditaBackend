
using Domain;
using MediatR;

namespace Application.CommandsQueries.Usuario_CommandsQueries;
public class GetUsuariosxLocal_idQuery : IRequest<IEnumerable<usuario>>
{
    public Int64 local_id { get; set; }
}
