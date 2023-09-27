
using Domain;
using MediatR;

namespace Application.CommandsQueries.Usuario_CommandsQueries
{
    public class CreateUsuarioCajaCommand : IRequest<ServiceResponse>
    {
        public usuarioCajaNuevo NewUsuario { get; set; }
    }
}
