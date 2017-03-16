using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ShippingPlatform.DataBase
{
    class LogisticCenterRepository
    {
        public LogisticCenterMapper GetLogisticCenter(IDbConnection connection, int searchId)
        {
            return connection.Query<LogisticCenterMapper>(
                "SELECT * FROM product WHERE id = @id",
                new { id = searchId }).FirstOrDefault();
        }

        public IEnumerable<LogisticCenter> GetAllLogisticCenters(IDbConnection connection)
        {
            return connection.Query<LogisticCenter>("SELECT * FROM logistic_centers").ToList();
        }
    }
}
