
using Domain;
using MediatR;

namespace Application.CommandsQueries.Usuario_CommandsQueries
{
    public class LoginUsuarioQuery : IRequest<usuarioResponse>
    {
        public usuarioLogin login { get; set; }
    }
}
