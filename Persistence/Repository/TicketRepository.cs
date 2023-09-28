

using Application.IRepository;
using Dapper;
using Domain;

namespace Persistence.Repository
{
    public class TicketRepository: ITicketRepository
    {
        private readonly DapperContext _context;
        public TicketRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ticket>> GetTicket()
        {
            var db = _context.CreateConnection();
            var sql = @" SELECT [id]
      ,[nroticket]
      ,[puntojuego_id]
      ,[credito]
      ,[monto]
      ,[fecharegistro]
      ,[estado]
  FROM [ticket]";
            return await db.QueryAsync<ticket>(sql);
        }

        public async Task<IEnumerable<ticket>> GetTicketoxPuntojuego_id(Int64 puntojuego_id)
        {
            var db = _context.CreateConnection();
            var sql = @"SELECT [id]
      ,[nroticket]
      ,[puntojuego_id]
      ,[credito]
      ,[monto]
      ,[fecharegistro]
      ,[estado]
  FROM [ticket]
                    where puntojuego_id=@puntojuego_id 
                    order by id asc";
            return await db.QueryAsync<ticket>(sql, new { puntojuego_id = puntojuego_id });
        }

        public async Task<IEnumerable<ticket>> GetTicketsxCaja_id(Int64 caja_id)
        {
            var db = _context.CreateConnection();
            var sql = @"SELECT t.[id]
      ,t.[nroticket]
      ,t.[puntojuego_id]
	  ,pj.ip puntojuego_ip
,pj.nro_punto puntojuego_nombre
	  ,c.id caja_id
	  ,c.nombre caja_nombre
      ,t.[credito]
      ,t.[monto]
      ,t.[fecharegistro]
      ,t.[estado]
  FROM [ticket] t
left join puntojuego pj on pj.id=t.puntojuego_id
left join local l on l.id = pj.local_id
left join caja c on c.local_id=pj.local_id 
where c.id=@caja_id 
                    order by t.id asc";
            return await db.QueryAsync<ticket>(sql, new { caja_id = caja_id });
        }

        public async Task<ticket> GetTicketxid(Int64 id)
        {
            var db = _context.CreateConnection();
            var sql = @"SELECT [id]
      ,[nroticket]
      ,[puntojuego_id]
      ,[credito]
      ,[monto]
      ,[fecharegistro]
      ,[estado]
  FROM [ticket] where id=@id";
            return await db.QueryFirstOrDefaultAsync<ticket>(sql, new { id = id });
        }

        public async Task<ticket> GetTicketxnroticket(string nroticket)
        {
            var db = _context.CreateConnection();
            var sql = @"SELECT [id]
      ,[nroticket]
      ,[puntojuego_id]
      ,[credito]
      ,[monto]
      ,[fecharegistro]
      ,[estado]
  FROM [ticket] where nroticket=@nroticket";
            return await db.QueryFirstOrDefaultAsync<ticket>(sql, new { nroticket = nroticket });
        }

        public async Task<tickettransaccion> GetTicketSaldoxticket_id(Int64 id)
        {
            var db = _context.CreateConnection();
            var sql = @"
SELECT top 1 t.[id] ticket_id
      , t.[nroticket]
      , t.[puntojuego_id]
      , t.[credito]
      , t.[monto]
      , t.[fecharegistro]
      , t.[estado]
        ,tr.id transaccion_id
        ,tr.estadocobro
        ,tr.jugada
        ,tr.premio
	  ,tr.comprobantepagonro
	  ,tr.caja_id
	  ,tr.saldoticketini
	  ,tr.saldoticketfin
	  ,tr.estadopago
	  ,tr.fechacobro
  FROM [ticket] t 
  left join transacciones tr on tr.nroticket=t.nroticket
  where t.id=@id
  order by tr.id desc";
            return await db.QueryFirstOrDefaultAsync<tickettransaccion>(sql, new { id = id });
        }

        public async Task<tickettransaccion> GetTicketSaldoxticket_nro(string nroticket)
        {
            var db = _context.CreateConnection();
            var sql = @"
SELECT top 1 t.[id] ticket_id
      , t.[nroticket]
      , t.[puntojuego_id]
      , t.[credito]
      , t.[monto]
      , t.[fecharegistro]
      , t.[estado]
        ,tr.id transaccion_id
,tr.jugada
,tr.premio
,tr.importepremio
,tr.estadocobro
	  ,tr.comprobantepagonro
	  ,tr.caja_id
	  ,tr.saldoticketini
	  ,tr.saldoticketfin
	  ,tr.estadopago
	  ,tr.fechacobro
  FROM [ticket] t 
  left join transacciones tr on tr.nroticket=t.nroticket
  where t.nroticket=@nroticket
  order by tr.id desc";
            return await db.QueryFirstOrDefaultAsync<tickettransaccion>(sql, new { nroticket = nroticket });
        }

        public async Task<Int64> CreateTicket(ticket ticket)
        {
            var db = _context.CreateConnection();
            var sql = @"INSERT INTO [ticket]
           ([nroticket],[puntojuego_id],apertura_id,[credito],[monto],[fecharegistro],[estado])
     VALUES
            (@nroticket,@puntojuego_id,@apertura_id,@credito ,@monto,@fecharegistro,@estado)  SELECT SCOPE_IDENTITY()";
            var result = await db.QueryAsync<Int64>(sql, ticket);
            return result.Single();
        }

        public async Task<bool> UpdateTicket_nro(Int64 id,string nroticket)
        {
            var db = _context.CreateConnection();
            var sql = @"UPDATE ticket
                                SET
                                    nroticket=@nroticket
                                     where id=@id";
            var result = await db.ExecuteAsync(
                    sql, new {id=id, nroticket = nroticket });
            return result > 0;
        }

        public async Task<bool> UpdateTicketEstado(ticket ticket)
        {
            var db = _context.CreateConnection();
            var sql = @"UPDATE ticket
                                SET
                                    estado = @estado where id=@id";
            var result = await db.ExecuteAsync(
                    sql, ticket);
            return result > 0;
        }

        public async Task<Int64> Createticketpago(createticketPago ticket)
        {
            var db = _context.CreateConnection();
            var sql = @"INSERT INTO [ticketpago]
           ([usuario_id],[caja_id],[ticket_id],[nroticket],[monto],[fecharegistro])
     VALUES
(@usuario_id,@caja_id,@ticket_id,@nroticket,@monto,@fecharegistro) SELECT SCOPE_IDENTITY()";
            var result = await db.QueryAsync<Int64>(sql, ticket);
            return result.Single();
        }

        public async Task<bool> UpdateTicketPago_nro(Int64 id, string nroticket)
        {
            var db = _context.CreateConnection();
            var sql = @"UPDATE ticketpago
                                SET
                                    nroticket=@nroticket
                                     where id=@id";
            var result = await db.ExecuteAsync(
                    sql, new { id = id, nroticket = nroticket });
            return result > 0;
        }

        public async Task<ticketPagoDetalle> GetTicketPagoxid(Int64 id)
        {
            var db = _context.CreateConnection();
            var sql = @"SELECT [id]
      ,[caja_id]
      ,[ticket_id]
      ,[nroticket]
      ,[monto]
      ,[fecharegistro]
  FROM [ticketpago] where id=@id";
            return await db.QueryFirstOrDefaultAsync<ticketPagoDetalle>(sql, new { id = id });
        }

        public async Task<ticketPagoDetalle> GetTicketPagoxticket_id(Int64 ticket_id)
        {
            var db = _context.CreateConnection();
            var sql = @"SELECT [id]
      ,[caja_id]
      ,[ticket_id]
      ,[nroticket]
      ,[monto]
      ,[fecharegistro]
  FROM [ticketpago] where ticket_id=@ticket_id";
            return await db.QueryFirstOrDefaultAsync<ticketPagoDetalle>(sql, new { ticket_id = ticket_id });
        }
    }
}
