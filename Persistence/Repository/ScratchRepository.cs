using Application.IRepository;
using Dapper;
using Domain;

namespace Persistence.Repository
{
    public class ScratchRepository: IScratchRepository
    {
        private readonly DapperContext _context;
        public ScratchRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Scratch_Matrix>> GetMatrix()
        {
            var db = _context.CreateConnectionScratch();
            var sql = @"
SELECT id,[codigo]
      ,[simbolos]
      ,[simbPrem]
      ,[montoPremiado]
  FROM [MF_Matrix]";
            return await db.QueryAsync<Scratch_Matrix>(sql);
        }

        public async Task<Scratch_Matrix> GetMatrixPosicion(Int64 id)
        {
            var db = _context.CreateConnectionScratch();
            var sql = @"SELECT id,[codigo]
      ,[simbolos]
      ,[simbPrem]
      ,[montoPremiado]
  FROM [MF_Matrix]
                    where id=@id";
            return await db.QueryFirstOrDefaultAsync<Scratch_Matrix>(sql, new { id = id });
        }

        public async Task<IEnumerable<Scratch_Tp>> GetTp()
        {
            var db = _context.CreateConnectionScratch();
            var sql = @"
SELECT tp_value
  FROM [MF_TP]";
            return await db.QueryAsync<Scratch_Tp>(sql);
        }
    }
}
