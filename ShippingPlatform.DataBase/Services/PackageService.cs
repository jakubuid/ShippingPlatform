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

        public void DeletePackage(IDbConnection connection, int searchId)
        {
            packageRepository.DeletePackage(connection, searchId);
        }

        public IEnumerable<Package> AddPackage(IDbConnection connection, Package package)
        {
            return packageRepository.AddPackage(connection, package.height, package.width, package.depth,
                package.weight, package.content, package.orderId);
        }

        public Package UpdatePackage(IDbConnection connection, Package package, int id)
        {
            return packageRepository.UpdatePackage(connection, package, id);
        }
    }
}