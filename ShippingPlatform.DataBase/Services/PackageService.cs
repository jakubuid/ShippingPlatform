using System.Collections.Generic;
using System.Data;
using ShippingPlatform.DataBase.Repositories;

namespace ShippingPlatform.DataBase.Services
{
    public class PackageService
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
