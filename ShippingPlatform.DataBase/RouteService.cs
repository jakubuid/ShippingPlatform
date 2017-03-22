using System.Collections.Generic;
using System.Data;

namespace ShippingPlatform.DataBase
{
    public class RouteService
    {
        private RouteRepository routeRepository = new RouteRepository();

        public Route FindOneRoute(IDbConnection connection, int searchId)
        {
            return routeRepository.GetRoute(connection, searchId);
        }

        public IEnumerable<Route> FindAllRoutes(IDbConnection connection)
        {
            return routeRepository.GetAllRoutes(connection);
        }
    }
}
