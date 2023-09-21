
using Domain;
using MediatR;

namespace Application.CommandsQueries.Envio_CommandQueries
{
    public class CreateEnvioCommand : IRequest<ServiceResponse>
    {
        public envioNuevo NewEnvio { get; set; }
    }
}
