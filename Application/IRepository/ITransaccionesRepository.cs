using Domain;

namespace Application.IRepository
{
    public interface ITransaccionesRepository
    {
        Task<IEnumerable<transacciones>> GetTransacciones();
        Task<IEnumerable<transacciones>> GetTransaccionesxcajaPuntojuego_id(Int64 caja_id, int puntojuego_id);
        Task<bool> CreateTransaccion(transacciones transacciones);
        Task<bool> UpdateTransaccionPago(transacciones transacciones);
        Task<bool> Estadocobro(Int64 id, bool estadocobro);
    }
}
