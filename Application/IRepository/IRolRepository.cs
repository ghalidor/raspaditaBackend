
using Domain;

namespace Application.IRepository
{
    public interface IRolRepository
    {
        Task<IEnumerable<rol>> GetRol();
        Task<rol> GetDetalleRol(Int64 id);
        Task<bool> CreateRol(rol rol);
        Task<bool> UpdateRol(rol rol);
    }

}
