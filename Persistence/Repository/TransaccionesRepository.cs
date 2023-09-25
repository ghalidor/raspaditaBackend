
using Application.IRepository;
using Dapper;
using Domain;

namespace Persistence.Repository
{
    public class TransaccionesRepository: ITransaccionesRepository
    {
        private readonly DapperContext _context;
        public TransaccionesRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<transacciones>> GetTransacciones()
        {
            var db = _context.CreateConnection();
            var sql = @"SELECT [id]
      ,[caja_id]
      ,[puntojuego_id]
      ,[jugada]
      ,[premio]
      ,[importepremio]
      ,[nroticket]
      ,[estadocobro]
      ,[fechahorajugada]
      ,[saldoticketini]
      ,[saldoticketfin]
      ,[comprobanteventa]
      ,[comprobantepagonro]
      ,[fechacobro]
      ,[estadopago]
  FROM [transacciones]";
            return await db.QueryAsync<transacciones>(sql);
        }

        public async Task<IEnumerable<transacciones>> GetTransaccionesxcajaPuntojuego_id(Int64 caja_id,int puntojuego_id)
        {
            var db = _context.CreateConnection();
            var sql = @"SELECT [id]
      ,[caja_id]
      ,[puntojuego_id]
      ,[jugada]
      ,[premio]
      ,[importepremio]
      ,[nroticket]
      ,[estadocobro]
      ,[fechahorajugada]
      ,[saldoticketini]
      ,[saldoticketfin]
      ,[comprobanteventa]
      ,[comprobantepagonro]
      ,[fechacobro]
      ,[estadopago]
  FROM [transacciones]
                    where local_id=@local_id and caja_id=@caja_id
                    order by id asc";
            return await db.QueryAsync<transacciones>(sql, new { caja_id = caja_id, puntojuego_id = puntojuego_id });
        }

        public async Task<bool> CreateTransaccion(transacciones transacciones)
        {
            var db = _context.CreateConnection();
            var sql = @"INSERT INTO [transacciones]
           ([caja_id]
           ,[puntojuego_id]
           ,[jugada]
           ,[premio]
           ,[importepremio]
           ,[nroticket]
           ,[estadocobro]
           ,[fechahorajugada]
           ,[saldoticketini]
           ,[saldoticketfin]
           ,[comprobanteventa]
           ,[comprobantepagonro]
           ,[estadopago])
     VALUES
(@caja_id,@puntojuego_id,@jugada,@premio,@importepremio,@nroticket,@estadocobro  ,@fechahorajugada,@saldoticketini,@saldoticketfin,@comprobanteventa,@comprobantepagonro,@estadopago)";
            var result = await db.ExecuteAsync(
                    sql, transacciones);
            return result > 0;
        }
    }
}
