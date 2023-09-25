
using Application.CommandsQueries.Rol_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.Rol_CommandsQueries
{
    public class UpdateRolCommandHandler : IRequestHandler<UpdateRolCommand, ServiceResponse>
    {
        private readonly IRolRepository _rolRepository;
        public UpdateRolCommandHandler(IRolRepository rolRepository)
        {
            _rolRepository = rolRepository;
        }

        public async Task<ServiceResponse> Handle(UpdateRolCommand request, CancellationToken cancellationToken)
        {
            if (request.EditRol is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }
            ServiceResponse response = new ServiceResponse();
            try
            {
                rol nuevo = new rol();
                nuevo.id = request.EditRol.id;
                nuevo.estado = request.EditRol.estado;
                nuevo.nombre = request.EditRol.nombre;
                bool respuesta = await _rolRepository.UpdateRol(nuevo);
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
            catch (Exception exp)
            {
                response.response = false;
                response.message = "Error ," + exp.Message;
            }

            return response;
        }

    }

}
