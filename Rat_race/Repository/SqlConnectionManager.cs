using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Rat_race.Repository
{
    public class SqlConnectionManager
    {
        string connectionString;

        public SqlConnectionManager(string dataSource, string initialCatalog,
                                    bool integratedSecurity = true, bool trustServerCertificate = true)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = dataSource,
                InitialCatalog = initialCatalog,
                IntegratedSecurity = integratedSecurity,
                TrustServerCertificate = trustServerCertificate
            };

            connectionString = builder.ConnectionString;
        }

        public SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }

        public void OpenConnection(SqlConnection connection)
        {
            connection.Open();
        }

        public void CloseConnection(SqlConnection connection)
        {
            connection.Close();
        }
    }
}
