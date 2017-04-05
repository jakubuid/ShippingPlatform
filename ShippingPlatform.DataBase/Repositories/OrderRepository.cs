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
            return connection.Query<Order, Address, Address, Order>(
                @"SELECT * FROM orders
                INNER JOIN addresses a1 ON orders.id_client_address = a1.id_addresses
                INNER JOIN addresses a2 ON orders.id_recipient_address = a2.id_addresses 
                WHERE id_orders = @id",
                (client, cAddress, rAddress) =>
                {
                    client.clientAddress = cAddress;
                    client.recipientAddress = rAddress;
                    return client;
                },
                new {id = searchId}, splitOn: "id_addresses").FirstOrDefault();
        }

        public IEnumerable<Order> GetAllOrders(IDbConnection connection)
        {
            return connection.Query<Order, Address, Address, Order>(
                @"SELECT * FROM orders
                INNER JOIN addresses a1 ON orders.id_client_address = a1.id_addresses
                INNER JOIN addresses a2 ON orders.id_recipient_address = a2.id_addresses",
                (client, cAddress, rAddress) =>
                {
                    client.clientAddress = cAddress;
                    client.recipientAddress = rAddress;
                    return client;
                }, splitOn: "id_addresses").ToList();
        }
    }
}