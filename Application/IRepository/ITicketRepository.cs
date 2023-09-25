using Domain;

namespace Application.IRepository
{
    public interface ITicketRepository
    {
        Task<IEnumerable<ticket>> GetTicket();
        Task<IEnumerable<ticket>> GetTicketoxPuntojuego_id(Int64 puntojuego_id);
        Task<IEnumerable<ticket>> GetTicketsxCaja_id(Int64 caja_id);
        Task<ticket> GetTicketxid(Int64 id);
        Task<Int64> CreateTicket(ticket envio);
        Task<bool> UpdateTicket_nro(Int64 id, string nro_ticket);
        Task<bool> UpdateTicketEstado(ticket ticket);
    }
}
