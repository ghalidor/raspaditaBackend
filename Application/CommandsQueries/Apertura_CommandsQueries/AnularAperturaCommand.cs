
using Domain;
using MediatR;

namespace Application.CommandsQueries.Apertura_CommandsQueries;
public class AnularAperturaCommand : IRequest<ServiceResponse>
{
    public aperturaCerrar apertura { get; set; }
}
