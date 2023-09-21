using Domain;

namespace Application.IRepository
{
    public interface ILocalRepository
    {
        Task<IEnumerable<local>> GetLocal();
        Task<local> GetDetalleLocal(Int64 id);
        Task<bool> CreateLocal(local envio);
    }
}
