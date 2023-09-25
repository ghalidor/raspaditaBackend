
using Application.CommandsQueries.Local_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.Local_CommandsQueries
{
    public class UpdateLocalCommandHandler : IRequestHandler<UpdateLocalCommand, ServiceResponse>
    {
        private readonly ILocalRepository _localRepository;
        public UpdateLocalCommandHandler(ILocalRepository localRepository)
        {
            _localRepository = localRepository;
        }

        public async Task<ServiceResponse> Handle(UpdateLocalCommand request, CancellationToken cancellationToken)
        {
            if(request.EditLocal is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }
            ServiceResponse response = new ServiceResponse();
            try
            {
                local nuevo = new local();
                nuevo.id = request.EditLocal.id;
                nuevo.fechaupdated = DateTime.Now;
                nuevo.formato = request.EditLocal.formato;
                nuevo.direccion = request.EditLocal.direccion;
                nuevo.nombre = request.EditLocal.nombre;
                nuevo.estado = request.EditLocal.estado;
                bool respuesta = await _localRepository.UpdateLocal(nuevo);
                response.response = respuesta;
                if(respuesta)
                {
                    response.message = "Se registró Corréctamente";
                }
                else
                {
                    response.message = "Error , no se pudo registrar";
                }
            }
            catch(Exception exp)
            {
                response.response = false;
                response.message = "Error ," + exp.Message;
            }

            return response;
        }
    }
}
