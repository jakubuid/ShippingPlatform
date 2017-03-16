
using System.Collections.Generic;
using System.Data;

namespace ShippingPlatform.DataBase
{
    class PackageService
    {
        private PackageRepository packageRepository = new PackageRepository();

        public Package FindOnePackage(IDbConnection connection, int searchId)
        {
            return packageRepository.GetPackage(connection, searchId);
        }

        public IEnumerable<Package> FindAllPackages(IDbConnection connection)
        {
            return packageRepository.GetAllPackages(connection);
        }
    }
}
