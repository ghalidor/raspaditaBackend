
using Domain;
using MediatR;

namespace Application.CommandsQueries.Apertura_CommandsQueries
{
    public class CloseAperturaCommand : IRequest<ServiceResponse>
    {
        public aperturaCerrar apertura { get; set; }
    }
}
