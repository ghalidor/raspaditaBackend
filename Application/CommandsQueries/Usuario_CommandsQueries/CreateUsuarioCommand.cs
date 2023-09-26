
using Domain;
using MediatR;

namespace Application.CommandsQueries.Usuario_CommandsQueries
{
    public class CreateUsuarioCommand : IRequest<ServiceResponse>
    {
        public usuarioNuevo NewUsuario { get; set; }
    }
}
