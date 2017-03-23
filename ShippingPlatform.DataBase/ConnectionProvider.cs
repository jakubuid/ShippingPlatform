using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static Dapper.SqlMapper;

namespace ShippingPlatform.DataBase
{
    public static class ConnectionProvider
    {
        public static string GetConnectionString()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.Password = "root";
            builder.Database = "shippingplatformdb";
            builder.UserID = "root";
            return builder.GetConnectionString(true);
        }
        public static IDbConnection GetConnection()
        {
            IDbConnection connection = new MySqlConnection(GetConnectionString());
            connection.Open();
            return connection;
        }
    }
}
