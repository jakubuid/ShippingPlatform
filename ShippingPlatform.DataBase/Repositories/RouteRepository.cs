using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ShippingPlatform.DataBase.Repositories
{
    class RouteRepository
    {
        public Route GetRoute(IDbConnection connection, int searchId)
        {
            return connection.Query<Route>(
                "SELECT * FROM routes WHERE id_routes = @id",
                new { id = searchId }).FirstOrDefault();
        }

        public IEnumerable<Route> GetAllRoutes(IDbConnection connection)
        {
            return connection.Query<Route>("SELECT * FROM routes").ToList();
        }
    }
}
