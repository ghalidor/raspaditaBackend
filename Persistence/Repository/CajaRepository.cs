using Application.IRepository;
using Dapper;
using Domain;

namespace Persistence.Repository
{
    public class CajaRepository: ICajaRepository
    {
        private readonly DapperContext _context;
        public CajaRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<caja>> GetCajas()
        {
            var db = _context.CreateConnection();
            var sql = @" SELECT id
      ,[local_id]
      ,[fechaoperacion]
      ,[fechaapertura]
      ,[nro_apertura]
      ,[fechacierre]
      ,[usuario_id]
      ,[estado] FROM [caja]";
            return await db.QueryAsync<caja>(sql);
        }

        public async Task<IEnumerable<caja>> GetCajasxlocal_id(Int64 local_id)
        {
            var db = _context.CreateConnection();
            var sql = @" SELECT id
      ,[local_id]
      ,[fechaoperacion]
      ,[fechaapertura]
      ,[nro_apertura]
      ,[fechacierre]
      ,[usuario_id]
      ,[estado] FROM [caja]
                    where local_id=@local_id 
                    order by id asc";
            return await db.QueryAsync<caja>(sql, new { local_id = local_id });
        }

        public async Task<IEnumerable<caja>> GetCajasxlocal_idxfechahoy(Int64 local_id,DateTime fecha)
        {
            var db = _context.CreateConnection();
            var sql = @" SELECT id
      ,[local_id]
      ,[fechaoperacion]
      ,[fechaapertura]
      ,[nro_apertura]
      ,[fechacierre]
      ,[usuario_id]
      ,[estado] FROM [caja]
                    where local_id=@local_id and convert(date,fechaapertura)= convert(date,@fecha)
                    order by id asc";
            return await db.QueryAsync<caja>(sql, new { local_id = local_id, fecha= fecha });
        }
        

        public async Task<bool> CreateCaja(caja caja)
        {
            var db = _context.CreateConnection();
            var sql = @"INSERT INTO [caja]
           ([local_id]
           ,[fechaoperacion]
           ,[fechaapertura]
           ,[nro_apertura]
           ,[usuario_id]
           ,[estado])
     VALUES
(@local_id,@fechaoperacion,@fechaapertura,@nro_apertura,@usuario_id,@estado)";
            var result = await db.ExecuteAsync(
                    sql, caja);
            return result > 0;
        }

        public async Task<bool> CloseCaja(caja caja)
        {
            var db = _context.CreateConnection();
            var sql = @"UPDATE caja
                                SET
                                    fechacierre = @fechacierre,
                                    estado = @estado
                                     where id=@id";
            var result = await db.ExecuteAsync(
                    sql, caja);
            return result > 0;
        }

    }
}
