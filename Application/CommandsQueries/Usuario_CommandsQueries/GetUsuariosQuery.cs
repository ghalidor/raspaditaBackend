
using Domain;
using MediatR;

namespace Application.CommandsQueries.Usuario_CommandsQueries
{
    public class GetUsuariosQuery : IRequest<IEnumerable<usuario>>
    {
    }
}
