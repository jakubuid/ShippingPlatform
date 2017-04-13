using ShippingPlatform.DataBase.Repositories;
using System.Collections.Generic;
using System.Data;

namespace ShippingPlatform.DataBase.Services
{
    public class RouteService
    {
        private RouteRepository _routRepository = new RouteRepository();

        public Route FindOneRoute(IDbConnection connection, int searchId)
        {
            return _routRepository.GetRoute(connection, searchId);
        }

        public IEnumerable<Route> FindAllRoutes(IDbConnection connection)
        {
            return _routRepository.GetAllRoutes(connection);
        }
    }
}
