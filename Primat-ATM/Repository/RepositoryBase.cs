using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primat_ATM.Repository
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionString;
        public RepositoryBase()
        {
            var root = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;
            var path = Path.Combine(root, ".env");
            DotEnv.Load(path);

            string server = Environment.GetEnvironmentVariable("SERVER");
            string database = Environment.GetEnvironmentVariable("DATABASE");
            string uid = Environment.GetEnvironmentVariable("UID");
            string password = Environment.GetEnvironmentVariable("PASSWORD");

            _connectionString = $"Server={server};Database={database};Uid={uid};Password={password}";
        }

        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}
