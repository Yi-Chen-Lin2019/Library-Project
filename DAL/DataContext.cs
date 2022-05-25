using System;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class DataContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public DataContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IDbConnection CreateConnection()
            => new System.Data.SqlClient.SqlConnection(_connectionString);
    }
}
