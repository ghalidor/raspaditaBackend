
using Application.IRepository;
using Dapper;
using Domain;

namespace Persistence.Repository {
    public class RolRepository: IRolRepository
    {
        private readonly DapperContext _context;
        public RolRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<rol>> GetRol()
        {
            var db = _context.CreateConnection();
            var sql = @"SELECT[id]
      ,[nombre]
      ,[fecharegistro]
      ,[estado]
FROM [rol] 
                    order by id asc";
            return await db.QueryAsync<rol>(sql);
        }

        public async Task<rol> GetDetalleRol(Int64 id)
        {
            var db = _context.CreateConnection();
            var sql = @"SELECT[id]
      ,[nombre]
      ,[fecharegistro]
      ,[estado]
FROM [rol] 
                    where id=@id 
                    order by id asc";
            return await db.QueryFirstOrDefaultAsync<rol>(sql, new { id = id });
        }

        public async Task<bool> CreateRol(rol rol)
        {
            var db = _context.CreateConnection();
            var sql = @"INSERT INTO [rol]
           ([nombre],[fecharegistro],[estado])
     VALUES
(@nombre,@fecharegistro,@estado)";
            var result = await db.ExecuteAsync(
                    sql, rol);
            return result > 0;
        }

        public async Task<bool> UpdateRol(rol rol)
        {
            var db = _context.CreateConnection();
            var sql = @"UPDATE  rol
           set nombre=@nombre
           ,estado=@estado where id=@id";
            var result = await db.ExecuteAsync(
                    sql, rol);
            return result > 0;
        }
    }

}
