using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Persistence
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private readonly string _connectionStringScratch;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
            _connectionStringScratch = _configuration.GetConnectionString("DefaultConnectionScratch");

        }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
        public IDbConnection CreateConnectionScratch() => new SqlConnection(_connectionStringScratch);
    }
}