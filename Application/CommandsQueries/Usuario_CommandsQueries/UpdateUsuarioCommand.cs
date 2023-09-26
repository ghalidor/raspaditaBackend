
using Domain;
using MediatR;

namespace Application.CommandsQueries.Usuario_CommandsQueries
{
    public class UpdateUsuarioCommand : IRequest<ServiceResponse>
    {
        public usuarioEditar EditUsuario { get; set; }
    }
}
