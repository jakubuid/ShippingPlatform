using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ShippingPlatform.DataBase.Repositories
{
    class RouteRepository
    {
        public Route GetRoute(IDbConnection connection, int searchId)
        {
            return connection.Query<Route, Address, Address, Order, Address, Address, Route>(
                    @"SELECT * FROM routes
                INNER JOIN addresses a1 ON routes.id_start_address = a1.id_addresses
                INNER JOIN addresses a2 ON routes.id_end_address = a2.id_addresses
                INNER JOIN orders o ON routes.id_order = o.id_orders
                INNER JOIN addresses a3 ON o.id_client_address = a3.id_addresses
                INNER JOIN addresses a4 ON o.id_recipient_address = a4.id_addresses
                WHERE id_routes = @id",
                    (route, sAddress, eAddress, order, orderRecipientAddress, orderClientAddress) =>
                    {
                        route.startAddress = sAddress;
                        route.endAddress = eAddress;
                        route.order = order;
                        order.clientAddress = orderClientAddress;
                        order.recipientAddress = orderRecipientAddress;
                        return route;
                    },
                    new {id = searchId}, splitOn: "id_addresses, id_addresses ,id_orders, id_addresses,id_addresses")
                .FirstOrDefault();
        }

        public IEnumerable<Route> GetAllRoutes(IDbConnection connection)
        {
            return connection.Query<Route, Address, Address, Order, Address, Address, Route>(
                @"SELECT * FROM routes
                INNER JOIN addresses a1 ON routes.id_start_address = a1.id_addresses
                INNER JOIN addresses a2 ON routes.id_end_address = a2.id_addresses
                INNER JOIN orders o ON routes.id_order = o.id_orders
                INNER JOIN addresses a3 ON o.id_client_address = a3.id_addresses
                INNER JOIN addresses a4 ON o.id_recipient_address = a4.id_addresses",
                (route, sAddress, eAddress, order, orderRecipientAddress, orderClientAddress) =>
                {
                    route.startAddress = sAddress;
                    route.endAddress = eAddress;
                    route.order = order;
                    order.clientAddress = orderClientAddress;
                    order.recipientAddress = orderRecipientAddress;
                    return route;
                }, splitOn: "id_addresses, id_addresses, id_orders, id_addresses,id_addresses").ToList();
        }
    }
}