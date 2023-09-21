
using Domain;

namespace Application.IRepository
{
    public interface ICajaRepository
    {
        Task<IEnumerable<caja>> GetCajas();
        Task<IEnumerable<caja>> GetCajasxlocal_id(Int64 local_id);
        Task<bool> CreateCaja(caja caja);
        Task<bool> CloseCaja(caja caja);
    }
}
