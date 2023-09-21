

using Application.IRepository;
using Dapper;
using Domain;

namespace Persistence.Repository
{
    public class EnvioRepository: IEnvioRepository
    {
        private readonly DapperContext _context;
        public EnvioRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<envio>> GetEnvio()
        {
            var db = _context.CreateConnection();
            var sql = @" SELECT [id]
      ,[nroticket]
      ,[puntojuego_id]
      ,[credito]
      ,[fecharegistro]
      ,[estado]
  FROM [envio]";
            return await db.QueryAsync<envio>(sql);
        }

        public async Task<IEnumerable<envio>> GetEnvioxPuntojuego_id(Int64 puntojuego_id)
        {
            var db = _context.CreateConnection();
            var sql = @" SELECT [id]
      ,[nroticket]
      ,[puntojuego_id]
      ,[credito]
      ,[fecharegistro]
      ,[estado]
  FROM [envio]
                    where puntojuego_id=@puntojuego_id 
                    order by id asc";
            return await db.QueryAsync<envio>(sql, new { puntojuego_id = puntojuego_id });
        }

        public async Task<bool> CreateEnvio(envio envio)
        {
            var db = _context.CreateConnection();
            var sql = @"INSERT INTO [envio]
           ([nroticket]
           ,[puntojuego_id]
           ,[credito]
           ,[fecharegistro]
           ,[estado])
     VALUES
(@nroticket,@puntojuego_id,@credito,@fecharegistro,@estado)";
            var result = await db.ExecuteAsync(
                    sql, envio);
            return result > 0;
        }

    }
}
