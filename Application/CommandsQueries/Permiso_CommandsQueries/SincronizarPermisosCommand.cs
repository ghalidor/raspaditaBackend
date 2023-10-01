using Domain;
using MediatR;

namespace Application.CommandsQueries.Permiso_CommandsQueries
{
    public class SincronizarPermisosCommand:IRequest<ServiceResponse>
    {
        public List<permiso> listapermisos { get; set; }
    }
}
