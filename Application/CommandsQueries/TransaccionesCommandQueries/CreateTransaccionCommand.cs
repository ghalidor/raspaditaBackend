
using Domain;
using MediatR;

namespace Application.CommandsQueries.TransaccionesCommandQueries
{
    public class CreateTransaccionCommand : IRequest<ServiceResponse>
    {
        public transaccionesNuevo NewTransacciones { get; set; }
    }
}
