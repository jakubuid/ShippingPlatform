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
            return connection.Query<Package, Order, Package>(
                @"SELECT * FROM packages
                INNER JOIN orders o ON packages.id_order = o.id_orders
                WHERE id_packages = @id",
                (packages, order) =>
                {
                    packages.order = order;
                    return packages;
                },
                new { id = searchId }, splitOn: "id_orders").FirstOrDefault();
        }

        public IEnumerable<Package> GetAllPackages(IDbConnection connection)
        {
            return connection.Query<Package, Order, Package>(
                @"SELECT * FROM packages
                INNER JOIN orders o ON packages.id_order = o.id_orders",
                (packages, order) =>
                {
                    packages.order = order;
                    return packages;
                }, splitOn: "id_orders").ToList();
        }
    }
}
