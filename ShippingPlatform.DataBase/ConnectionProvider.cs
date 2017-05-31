using MySql.Data.MySqlClient;
using System.Data;

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