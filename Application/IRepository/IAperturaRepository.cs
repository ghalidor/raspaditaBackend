
using Domain;

namespace Application.IRepository
{
    public interface IAperturaRepository
    {
        Task<IEnumerable<apertura>> GetAperturaxlocal_id(Int64 local_id);
        Task<IEnumerable<apertura>> GetAperturaxlocal_idxfechahoy(Int64 local_id, Int64 caja_id, DateTime fechaHoy);
        Task<bool> CreateApertura(apertura apertura);
        Task<bool> CloseApertura(apertura apertura);
    }
}
