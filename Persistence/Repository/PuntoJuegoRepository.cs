
using Application.IRepository;
using Dapper;
using Domain;

namespace Persistence.Repository
{
    public class PuntoJuegoRepository: IPuntoJuegoRepository
    {
        private readonly DapperContext _context;
        public PuntoJuegoRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<puntojuego>> GetPuntojuego()
        {
            var db = _context.CreateConnection();
            var sql = @"SELECT [id]
      ,[local_id]
      ,[nro_punto]
      ,[ip]
      ,[estado]
  FROM [puntojuego]";
            return await db.QueryAsync<puntojuego>(sql);
        }

        public async Task<IEnumerable<puntojuego>> GetPuntoJuegoxLocal_id(Int64 local_id)
        {
            var db = _context.CreateConnection();
            var sql = @" SELECT [id]
      ,[local_id]
      ,[nro_punto]
      ,[ip]
      ,[estado]
  FROM [puntojuego]
                    where local_id=@local_id 
                    order by id asc";
            return await db.QueryAsync<puntojuego>(sql, new { local_id = local_id });
        }

        public async Task<bool> CreatePuntoJuego(puntojuego puntojuego)
        {
            var db = _context.CreateConnection();
            var sql = @"INSERT INTO [puntojuego]
           ([local_id]
           ,[nro_punto]
           ,[ip]
           ,[estado])
     VALUES
(@local_id,@nro_punto,@ip,@estado)";
            var result = await db.ExecuteAsync(
                    sql, puntojuego);
            return result > 0;
        }
    }
}
