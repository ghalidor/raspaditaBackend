
using Domain;

namespace Application.IRepository
{
    public interface ICajaRepository
    {
        Task<IEnumerable<caja>> GetCaja();
        Task<IEnumerable<caja>> GetCajaxlocal_id(Int64 local_id);
        Task<caja> GetDetalleCaja(Int64 id);
        Task<bool> CreateCaja(caja caja);
        Task<bool> UpdateCaja(caja caja);
    }
}
