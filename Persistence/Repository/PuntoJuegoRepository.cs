
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
      ,[fecharegistro]
      ,[fechaupdated]
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
 ,[fecharegistro]
      ,[fechaupdated]
      ,[estado]
  FROM [puntojuego]
                    where local_id=@local_id 
                    order by id asc";
            return await db.QueryAsync<puntojuego>(sql, new { local_id = local_id });
        }

        public async Task<puntojuego> GetPuntoJuegoDetalle(Int64 id)
        {
            var db = _context.CreateConnection();
            var sql = @" SELECT [id]
      ,[local_id]
      ,[nro_punto]
      ,[ip]
 ,[fecharegistro]
      ,[fechaupdated]
      ,[estado]
  FROM [puntojuego]
                    where id=@id";
            return await db.QueryFirstOrDefaultAsync<puntojuego>(sql, new { id = id });
        }

        public async Task<puntojuego> GetPuntoJuegoDetallexIp(string ip)
        {
            var db = _context.CreateConnection();
            var sql = @" SELECT [id]
      ,[local_id]
      ,[nro_punto]
      ,[ip]
 ,[fecharegistro]
      ,[fechaupdated]
 ,[posicion]
      ,[estado]
  FROM [puntojuego]
                    where ip=@ip";
            return await db.QueryFirstOrDefaultAsync<puntojuego>(sql, new { ip = ip });
        }

        public async Task<bool> UpdatePuntoJuegoPosicion(Int64 id, Int64 posision)
        {
            var db = _context.CreateConnection();
            var sql = @"UPDATE  puntojuego
          set  
           posicion=@posicion
            where id=@id";
            var result = await db.ExecuteAsync(
                    sql, new{id=id,posicion=posision });
            return result > 0;
        }

        public async Task<bool> CreatePuntoJuego(puntojuego puntojuego)
        {
            var db = _context.CreateConnection();
            var sql = @"INSERT INTO [puntojuego]
           ([local_id]
           ,[nro_punto]
 ,[fecharegistro]
           ,[ip]
           ,[estado])
     VALUES
(@local_id,@nro_punto,@fecharegistro,@ip,@estado)";
            var result = await db.ExecuteAsync(
                    sql, puntojuego);
            return result > 0;
        }

        public async Task<bool> UpdatePuntoJuego(puntojuego puntojuego)
        {
            var db = _context.CreateConnection();
            var sql = @"UPDATE  puntojuego
          set  local_id=@local_id
           ,nro_punto=@nro_punto
 ,fechaupdated=@fechaupdated
           ,ip=@ip
           ,estado=@estado
            where id=@id";
            var result = await db.ExecuteAsync(
                    sql, puntojuego);
            return result > 0;
        }

       
    }
}
