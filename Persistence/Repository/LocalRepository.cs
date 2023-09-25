
using Application.IRepository;
using Dapper;
using Domain;

namespace Persistence.Repository
{
    public class LocalRepository: ILocalRepository
    {
        private readonly DapperContext _context;
        public LocalRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<local>> GetLocal()
        {
            var db = _context.CreateConnection();
            var sql = @"SELECT [id]
      ,[nombre]
      ,[direccion]
      ,[formato]
      ,[fecharegistro]
      ,[fechaupdated]
      ,[estado]
  FROM [local]";
            return await db.QueryAsync<local>(sql);
        }

        public async Task<local> GetDetalleLocal(Int64 id)
        {
            var db = _context.CreateConnection();
            var sql = @"SELECT[id]
      ,[nombre]
      ,[direccion]
      ,[formato]
      ,[fecharegistro]
      ,[fechaupdated]
      ,[estado]
  FROM [local]
                    where id=@id 
                    order by id asc";
            return await db.QueryFirstOrDefaultAsync<local>(sql, new { id = id });
        }

        public async Task<bool> CreateLocal(local local)
        {
            var db = _context.CreateConnection();
            var sql = @"INSERT INTO [local]
           ([nombre]
           ,[direccion]
           ,[formato]
           ,[fecharegistro]
           ,[estado])
     VALUES
(@nombre,@direccion,@formato,@fecharegistro,@estado)";
            var result = await db.ExecuteAsync(
                    sql, local);
            return result > 0;
        }

        public async Task<bool> UpdateLocal(local local)
        {
            var db = _context.CreateConnection();
            var sql = @"UPDATE [local]
            set nombre=@nombre
           ,direccion=@direccion
           ,formato=@formato
           ,fechaupdated=@fechaupdated
           ,estado  = @estado
                where id=@id
";
            var result = await db.ExecuteAsync(
                    sql, local);
            return result > 0;
        }
    }
}
