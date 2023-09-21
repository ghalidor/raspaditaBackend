
using Domain;

namespace Application.IRepository
{
    public interface IPuntoJuegoRepository
    {
        Task<IEnumerable<puntojuego>> GetPuntojuego();
        Task<IEnumerable<puntojuego>> GetPuntoJuegoxLocal_id(Int64 local_id);
        Task<bool> CreatePuntoJuego(puntojuego puntojuego);
    }
}
