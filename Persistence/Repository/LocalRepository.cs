
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
      ,[fecharegistro]
      ,[formato]
      ,[estado]
  FROM [local]";
            return await db.QueryAsync<local>(sql);
        }

        public async Task<local> GetDetalleLocal(Int64 id)
        {
            var db = _context.CreateConnection();
            var sql = @"SELECT [id]
      ,[nombre]
      ,[direccion]
      ,[fecharegistro]
      ,[formato]
      ,[estado]
  FROM [local]
                    where id=@id 
                    order by id asc";
            return await db.QueryFirstOrDefaultAsync<local>(sql, new { id = id });
        }

        public async Task<bool> CreateLocal(local envio)
        {
            var db = _context.CreateConnection();
            var sql = @"INSERT INTO [local]
           ([nombre]
           ,[direccion]
           ,[fecharegistro]
           ,[formato]
           ,[estado])
     VALUES
(@nombre,@direccion,@fecharegistro,@formato,@estado)";
            var result = await db.ExecuteAsync(
                    sql, envio);
            return result > 0;
        }
    }
}
