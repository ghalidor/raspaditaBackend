
using Application.CommandsQueries.Local_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.Local_CommandsQueries
{
    public class CreateLocalCommandHandler : IRequestHandler<CreateLocalCommand, ServiceResponse>
    {
        private readonly ILocalRepository _localRepository;
        public CreateLocalCommandHandler(ILocalRepository localRepository)
        {
            _localRepository = localRepository;
        }

        public async Task<ServiceResponse> Handle(CreateLocalCommand request, CancellationToken cancellationToken)
        {
            if (request.NewLocal is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }
            ServiceResponse response = new ServiceResponse();
            try
            {
                local nuevo = new local();
                nuevo.fecharegistro = DateTime.Now;
                nuevo.estado = true;
                nuevo.formato = request.NewLocal.formato;
                nuevo.direccion = request.NewLocal.direccion;
                nuevo.nombre = request.NewLocal.nombre;
                bool respuesta = await _localRepository.CreateLocal(nuevo);
                response.response = respuesta;
                if (respuesta)
                {               
                    response.message = "Se registró Corréctamente";
                }
                else
                {
                    response.message = "Error , no se pudo registrar";
                }
            }
            catch(Exception exp){
                response.response = false;
                response.message = "Error ,"+exp.Message;
            }
           
            return response;
        }

    }
}
