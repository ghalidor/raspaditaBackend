

namespace Persistence.Repository
{
    public class ScratchRespository
    {
        private readonly DapperContext _context;
        public ScratchRespository(DapperContext context)
        {
            _context = context;
        }

  //      public async Task<ticket> GetTicketxid(Int64 id)
  //      {
  //          var db = _context.CreateConnection();
  //          var sql = @"SELECT [id]
  //    ,[nroticket]
  //    ,[puntojuego_id]
  //    ,[credito]
  //    ,[monto]
  //    ,[fecharegistro]
  //    ,[estado]
  //FROM [ticket] where id=@id";
  //          return await db.QueryFirstOrDefaultAsync<ticket>(sql, new { id = id });
  //      }
    }
}
