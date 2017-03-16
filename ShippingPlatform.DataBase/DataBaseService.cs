using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ShippingPlatform.DataBase
{
    class DataBaseService
    {
        public string GetConnectionString()
        {
            return "test";
        }
        //public static IDbConnection GetConnection()
        //{
        //    using (IDbConnection connection = new MySqlConnection())
        //    {

        //    }
        //}
        public Client GetClient(IDbConnection connection, int searchId)
        {
            return connection.Query<Client>(
                "SELECT * FROM product WHERE id = @id",
                new {id = searchId}).FirstOrDefault();
        }

        public Order GetOrder(IDbConnection connection, int searchId)
        {
            return connection.Query<Order>(
                "SELECT * FROM product WHERE id = @id",
                new { id = searchId }).FirstOrDefault();
        }

        public Address GetAddress(IDbConnection connection, int searchId)
        {
            return connection.Query<Address>(
                "SELECT * FROM product WHERE id = @id",
                new { id = searchId }).FirstOrDefault();
        }

        public Notification GetNotification(IDbConnection connection, int searchId)
        {
            return connection.Query<Notification>(
                "SELECT * FROM product WHERE id = @id",
                new { id = searchId }).FirstOrDefault();
        }

        public Route GetRoute(IDbConnection connection, int searchId)
        {
            return connection.Query<Route>(
                "SELECT * FROM product WHERE id = @id",
                new { id = searchId }).FirstOrDefault();
        }

        public LogisticCenterMapper GetLogisticCenter(IDbConnection connection, int searchId)
        {
            return connection.Query<LogisticCenterMapper>(
                "SELECT * FROM product WHERE id = @id",
                new { id = searchId }).FirstOrDefault();
        }

        public Package GetPackage(IDbConnection connection, int searchId)
        {
            return connection.Query<Package>(
                "SELECT * FROM product WHERE id = @id",
                new { id = searchId }).FirstOrDefault();
        }

        public IEnumerable<Client> GetAllClients(IDbConnection connection)
        {
            return connection.Query<Client>("SELECT * FROM clients").ToList();
        }

        public IEnumerable<Package> GetAllPackages(IDbConnection connection)
        {
            return connection.Query<Package>("SELECT * FROM packages").ToList();
        }

        public IEnumerable<Route> GetAllRoutes(IDbConnection connection)
        {
            return connection.Query<Route>("SELECT * FROM routes").ToList();
        }

        public IEnumerable<Notification> GetAllNotifications(IDbConnection connection)
        {
            return connection.Query<Notification>("SELECT * FROM notifications").ToList();
        }

        public IEnumerable<Address> GetAllAddresses(IDbConnection connection)
        {
            return connection.Query<Address>("SELECT * FROM addresses").ToList();
        }

        public IEnumerable<LogisticCenterMapper> GetAllLogisticCenters(IDbConnection connection)
        {
            return connection.Query<LogisticCenterMapper>("SELECT * FROM logistic_centers").ToList();
        }

        public IEnumerable<Order> GetAllOrders(IDbConnection connection)
        {
            return connection.Query<Order>("SELECT * FROM orders").ToList();
        }
    }
}
