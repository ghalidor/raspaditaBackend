using Application.IRepository;
using Dapper;
using Domain;

namespace Persistence.Repository
{
    public class AperturaRepository: IAperturaRepository
    {
        private readonly DapperContext _context;
        public AperturaRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<apertura>> GetAperturaxlocal_id(Int64 local_id)
        {
            var db = _context.CreateConnection();
            var sql = @"SELECT [id]
      ,[local_id]
      ,[caja_id]
      ,[fechaoperacion]
      ,[fechaapertura]
      ,[nro_apertura]
      ,[fechacierre]
      ,[usuario_id]
      ,[estado]
 FROM [apertura]
                    where local_id=@local_id 
                    order by id asc";
            return await db.QueryAsync<apertura>(sql, new { local_id = local_id });
        }

        public async Task<IEnumerable<apertura>> GetAperturaxlocal_idxfechahoy(Int64 local_id, Int64 caja_id, DateTime fecha)
        {
            var db = _context.CreateConnection();
            var sql = @"SELECT [id]
      ,[local_id]
      ,[caja_id]
      ,[fechaoperacion]
      ,[fechaapertura]
      ,[nro_apertura]
      ,[fechacierre]
      ,[usuario_id]
      ,[estado]
FROM [apertura]
                    where local_id=@local_id and caja_id=@caja_id and convert(date,fechaoperacion)= convert(date,@fecha)
                    order by id asc";
            return await db.QueryAsync<apertura>(sql, new { local_id = local_id, caja_id = caja_id, fecha = fecha });
        }
        

        public async Task<bool> CreateApertura(apertura apertura)
        {
            var db = _context.CreateConnection();
            var sql = @"INSERT INTO [apertura]
           ([local_id] 
            ,[caja_id]
           ,[fechaoperacion]
           ,[fechaapertura]
           ,[nro_apertura]
           ,[usuario_id]
           ,[estado])
     VALUES
(@local_id,@caja_id,@fechaoperacion,@fechaapertura,@nro_apertura,@usuario_id,@estado)";
            var result = await db.ExecuteAsync(
                    sql, apertura);
            return result > 0;
        }

        public async Task<bool> CloseApertura(apertura apertura)
        {
            var db = _context.CreateConnection();
            var sql = @"UPDATE apertura
                                SET
                                    fechacierre = @fechacierre,
                                    estado = @estado
                                     where id=@id";
            var result = await db.ExecuteAsync(
                    sql, apertura);
            return result > 0;
        }

    }
}
