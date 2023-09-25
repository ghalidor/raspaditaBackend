
using Domain;
using MediatR;

namespace Application.CommandsQueries.Caja_CommandsQueries
{
    public class UpdateCajaCommand : IRequest<ServiceResponse>
    {
        public cajaEditar EditCaja { get; set; }
    }
}
