
using Application.CommandsQueries.Apertura_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.Apertura_CommandsQueries;
public class AnularAperturaCommandHandler : IRequestHandler<AnularAperturaCommand, ServiceResponse>
{
    private readonly IAperturaRepository _aperturaRepository;
    private readonly ICajaRepository _cajaRepository;
    public AnularAperturaCommandHandler(IAperturaRepository aperturaRepository,
        ICajaRepository cajaRepository)
    {
        _aperturaRepository = aperturaRepository;
        _cajaRepository = cajaRepository;
    }

    public async Task<ServiceResponse> Handle(AnularAperturaCommand request, CancellationToken cancellationToken)
    {
        if (request.apertura.id == 0)
        {
            throw new ApplicationException("There is a problem in mapper");
        }

        ServiceResponse response = new ServiceResponse();
        try
        {
            apertura nuevo = new apertura();
            DateTime fechaHoy = DateTime.Now;
            nuevo.estado = 3;
            nuevo.fechacierre = fechaHoy;
            nuevo.id = request.apertura.id;
            bool respuesta = await _aperturaRepository.CloseApertura(nuevo);
            response.response = respuesta;
            if (respuesta)
            {
                response.response = true;
                response.message = "Se Anuló Apertura Corréctamente";
            }
            else
            {
                response.response = false;
                response.message = "Error , no se pudo Anular";
            }

        }
        catch (Exception exp)
        {
            response.response = false;
            response.message = "Error ," + exp.Message;
        }

        return response;
    }
}
