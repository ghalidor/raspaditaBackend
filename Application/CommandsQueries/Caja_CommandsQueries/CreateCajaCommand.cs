
using Domain;
using MediatR;

namespace Application.CommandsQueries.Caja_CommandsQueries
{
    public class CreateCajaCommand : IRequest<ServiceResponse>
    {
        public cajaNuevo NewCaja { get; set; }
    }
}
