using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static Dapper.SqlMapper;

namespace ShippingPlatform.DataBase
{
    class ConnectionProvider
    {
        public static string GetConnectionString()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = Properties.Settings.Default.Server;
            builder.Password = Properties.Settings.Default.Password;
            builder.Database = Properties.Settings.Default.DataBase;
            builder.UserID = Properties.Settings.Default.Username;
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
