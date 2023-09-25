
using Application.CommandsQueries.Rol_CommandsQueries;
using Application.IRepository;
using Domain;
using MediatR;

namespace Application.Handlers.Rol_CommandsQueries
{
    public class CreateRolCommandHandler : IRequestHandler<CreateRolCommand, ServiceResponse>
    {
        private readonly IRolRepository _rolRepository;
        public CreateRolCommandHandler(IRolRepository rolRepository)
        {
            _rolRepository = rolRepository;
        }

        public async Task<ServiceResponse> Handle(CreateRolCommand request, CancellationToken cancellationToken)
        {
            if (request.NewRol is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }
            ServiceResponse response = new ServiceResponse();
            try
            {
                rol nuevo = new rol();
                nuevo.estado = true;
                nuevo.fecharegistro = DateTime.Now;
                nuevo.nombre = request.NewRol.nombre;
                bool respuesta = await _rolRepository.CreateRol(nuevo);
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
