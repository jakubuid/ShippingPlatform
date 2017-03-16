using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ShippingPlatform.DataBase
{
    class RouteRepository
    {
        public Route GetRoute(IDbConnection connection, int searchId)
        {
            return connection.Query<Route>(
                "SELECT * FROM product WHERE id = @id",
                new { id = searchId }).FirstOrDefault();
        }

        public IEnumerable<Route> GetAllRoutes(IDbConnection connection)
        {
            return connection.Query<Route>("SELECT * FROM routes").ToList();
        }
    }
}
