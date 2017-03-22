
using System.Collections.Generic;
using System.Data;

namespace ShippingPlatform.DataBase
{
    public class OrderService
    {
        private OrderRepository orderRepository = new OrderRepository();
        public Order FindOneOrder(IDbConnection connection, int searchId)
        {
            return orderRepository.GetOrder(connection, searchId);
        }

        public IEnumerable<Order> FindAllOrders(IDbConnection connection)
        {
            return orderRepository.GetAllOrders(connection);
        }
    }
}
