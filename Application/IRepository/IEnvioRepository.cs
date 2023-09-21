using Domain;

namespace Application.IRepository
{
    public interface IEnvioRepository
    {
        Task<IEnumerable<envio>> GetEnvio();
        Task<IEnumerable<envio>> GetEnvioxPuntojuego_id(Int64 puntojuego_id);
        Task<bool> CreateEnvio(envio envio);
    }
}
