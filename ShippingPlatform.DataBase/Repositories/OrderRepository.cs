using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ShippingPlatform.DataBase.Repositories
{
    class OrderRepository
    {
        public Order GetOrder(IDbConnection connection, int searchId)
        {
            return connection.Query<Order>(
                "SELECT * FROM orders WHERE id_orders = @id",
                new { id = searchId }).FirstOrDefault();
        }

        public IEnumerable<Order> GetAllOrders(IDbConnection connection)
        {
            return connection.Query<Order>("SELECT * FROM orders").ToList();
        }
    }
}
