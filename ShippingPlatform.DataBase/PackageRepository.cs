using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ShippingPlatform.DataBase
{
    class PackageRepository
    {
        public Package GetPackage(IDbConnection connection, int searchId)
        {
            return connection.Query<Package>(
                "SELECT * FROM packages WHERE id_packages = @id",
                new { id = searchId }).FirstOrDefault();
        }

        public IEnumerable<Package> GetAllPackages(IDbConnection connection)
        {
            return connection.Query<Package>("SELECT * FROM packages").ToList();
        }
    }
}
