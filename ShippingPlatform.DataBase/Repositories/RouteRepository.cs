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
            return connection.Query<Route, Address, Address, Order, Route>(
                @"SELECT * FROM routes
                INNER JOIN addresses a1 ON routes.id_start_address = a1.id_addresses
                INNER JOIN addresses a2 ON routes.id_end_address = a2.id_addresses
                INNER JOIN orders o ON routes.id_order = o.id_orders
                WHERE id_routes = @id",
                (route, sAddress, eAddress, order) =>
                {
                    route.startAddress = sAddress;
                    route.endAddress = eAddress;
                    route.order = order;
                    return route;
                },
                new {id = searchId}, splitOn: "id_addresses,id_addresses ,id_orders").FirstOrDefault();
        }

        public IEnumerable<Route> GetAllRoutes(IDbConnection connection)
        {
            return connection.Query<Route, Address, Address, Order, Route>(
                @"SELECT * FROM routes
                INNER JOIN addresses a1 ON routes.id_start_address = a1.id_addresses
                INNER JOIN addresses a2 ON routes.id_end_address = a2.id_addresses
                INNER JOIN orders o ON routes.id_order = o.id_orders",
                (route, sAddress, eAddress, order) =>
                {
                    route.startAddress = sAddress;
                    route.endAddress = eAddress;
                    route.order = order;
                    return route;
                }, splitOn: "id_addresses, id_addresses, id_orders").ToList();
        }
    }
}