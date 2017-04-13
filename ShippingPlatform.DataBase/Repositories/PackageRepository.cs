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
    }
}