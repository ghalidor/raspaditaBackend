

using Dapper;
using Domain;

namespace Persistence.Repository
{
    public class ScratchRespository
    {
        private readonly DapperContext _context;
        public ScratchRespository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Scratch_Matrix>> GetMatrix()
        {
            var db = _context.CreateConnectionScratch();
            var sql = @"
SELECT [codigo]
      ,[simbolos]
      ,[simbPrem]
      ,[montoPremiado]
  FROM [MF_Matrix]";
            return await db.QueryAsync<Scratch_Matrix>(sql);
        }

        public async Task<IEnumerable<Scratch_Tp>> GetTp()
        {
            var db = _context.CreateConnectionScratch();
            var sql = @"
SELECTtp_value
  FROM [MF_TP]";
            return await db.QueryAsync<Scratch_Tp>(sql);
        }
    }
}
