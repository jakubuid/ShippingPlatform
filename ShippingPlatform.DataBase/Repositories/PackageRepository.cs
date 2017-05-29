using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ShippingPlatform.DataBase.Repositories
{
    class PackageRepository
    {
        public Package GetPackage(IDbConnection connection, int searchId)
        {
            return connection.Query<Package, Order, Address, Address, Package>(
                @"SELECT * FROM packages
                INNER JOIN orders o ON packages.id_order = o.id_orders
                INNER JOIN addresses a3 ON o.id_client_address = a3.id_addresses
                INNER JOIN addresses a2 ON o.id_recipient_address = a2.id_addresses
                WHERE id_packages = @id",
                (packages, order, orderRecipientAddress, orderClientAddress) =>
                {
                    packages.order = order;
                    order.clientAddress = orderClientAddress;
                    order.recipientAddress = orderRecipientAddress;
                    return packages;
                },
                new {id = searchId}, splitOn: "id_orders,  id_addresses, id_addresses").FirstOrDefault();
        }

        public IEnumerable<Package> GetAllPackages(IDbConnection connection)
        {
            return connection.Query<Package, Order, Address, Address, Package>(
                @"SELECT * FROM packages
                INNER JOIN orders o ON packages.id_order = o.id_orders
                INNER JOIN addresses a3 ON o.id_client_address = a3.id_addresses
                INNER JOIN addresses a2 ON o.id_recipient_address = a2.id_addresses",
                (packages, order, orderRecipientAddress, orderClientAddress) =>
                {
                    packages.order = order;
                    order.clientAddress = orderClientAddress;
                    order.recipientAddress = orderRecipientAddress;
                    return packages;
                }, splitOn: "id_orders, id_addresses, id_addresses").ToList();
        }

        public void DeletePackage(IDbConnection connection, int searchId)
        {
            connection.Query<Package>
            (
                "DELETE FROM packages WHERE id_packages = @id",
                new {id = searchId});
        }

        public IEnumerable<Package> AddPackage(IDbConnection connection, double newHeight, double newWidth,
            double newDepth, double newWeight, string newContent, int newOrderId)
        {
            return connection.Query<Package>
            (
                @"INSERT INTO 
                packages(height, width, depth, weight, content, id_order)
                VALUES(@height, @width, @depth, @weight, @content, @id_order);",
                new
                {
                    height = newHeight,
                    width = newWidth,
                    depth = newDepth,
                    weight = newWeight,
                    content = newContent,
                    id_order = newOrderId
                });
        }
    }
}