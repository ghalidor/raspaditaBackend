
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

        public async Task<IEnumerable<caja>> GetCaja()
        {
            var db = _context.CreateConnection();
            var sql = @"SELECT [id]
      ,[local_id]
      ,[nombre]
      ,[fechaupdated]
      ,[fecharegistro]
      ,[estado]
FROM [caja] 
                    order by id asc";
            return await db.QueryAsync<caja>(sql);
        }

        public async Task<IEnumerable<caja>> GetCajaxlocal_id(Int64 local_id)
        {
            var db = _context.CreateConnection();
            var sql = @"SELECT [id]
      ,[local_id]
      ,[nombre]
      ,[fechaupdated]
      ,[fecharegistro]
      ,[estado]
FROM [caja] 
                    where local_id=@local_id 
                    order by id asc";
            return await db.QueryAsync<caja>(sql, new { local_id = local_id });
        }

        public async Task<caja> GetDetalleCaja(Int64 id)
        {
            var db = _context.CreateConnection();
            var sql = @"SELECT [id]
      ,[local_id]
      ,[nombre]
      ,[fechaupdated]
      ,[fecharegistro]
      ,[estado]
  FROM [caja]
                    where id=@id 
                    order by id asc";
            return await db.QueryFirstOrDefaultAsync<caja>(sql, new { id = id });
        }

        public async Task<bool> CreateCaja(caja caja)
        {
            var db = _context.CreateConnection();
            var sql = @"INSERT INTO [caja]
           ([local_id]
           ,[nombre]
           ,[fecharegistro]
           ,[estado])
     VALUES
(@local_id,@nombre,@fecharegistro,@estado)";
            var result = await db.ExecuteAsync(
                    sql, caja);
            return result > 0;
        }

        public async Task<bool> UpdateCaja(caja caja)
        {
            var db = _context.CreateConnection();
            var sql = @"UPDATE  caja
           set local_id=@local_id
           ,nombre=@nombre
           ,fechaupdated =@fechaupdated
           ,estado=@estado where id=@id";
            var result = await db.ExecuteAsync(
                    sql, caja);
            return result > 0;
        }
    }
}
