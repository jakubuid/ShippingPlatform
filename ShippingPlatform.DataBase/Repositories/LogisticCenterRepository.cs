using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ShippingPlatform.DataBase.Repositories
{
    class LogisticCenterRepository
    {
        public LogisticCenter GetLogisticCenter(IDbConnection connection, int searchId)
        {
            return connection.Query<LogisticCenter, Address, Route,Address ,Address, Order, LogisticCenter>(
                @"SELECT * FROM logistic_centers
                INNER JOIN addresses a ON logistic_centers.id_logistic_center_address = a.id_addresses
                INNER JOIN routes r ON logistic_centers.id_shipping_route = r.id_routes
                INNER JOIN addresses a3 ON r.id_start_address = a3.id_addresses
                INNER JOIN addresses a2 ON r.id_end_address = a2.id_addresses
                INNER JOIN orders o ON r.id_order = o.id_orders
                WHERE id_logistic_centers = @id",
                (logisticCenter, address, route, startAddress, endAddress, routeOrder) =>
                {
                    logisticCenter.logisticCenterAddress = address;
                    logisticCenter.shippingRoute = route;
                    route.startAddress = startAddress;
                    route.endAddress = endAddress;
                    route.order = routeOrder;
                    return logisticCenter;
                },
                new {id = searchId}, splitOn: "id_addresses, id_routes, id_addresses, id_addresses, id_orders").FirstOrDefault();
        }

        public IEnumerable<LogisticCenter> GetAllLogisticCenters(IDbConnection connection)
        {
            return connection.Query<LogisticCenter, Address, Route, LogisticCenter>(
                @"SELECT * FROM logistic_centers
                INNER JOIN addresses a ON logistic_centers.id_logistic_center_address = a.id_addresses
                INNER JOIN routes r ON logistic_centers.id_shipping_route = r.id_routes",
                (logisticCenter, address, route) =>
                {
                    logisticCenter.logisticCenterAddress = address;
                    logisticCenter.shippingRoute = route;
                    return logisticCenter;
                }, splitOn: "id_addresses, id_routes").ToList();
        }
    }
}