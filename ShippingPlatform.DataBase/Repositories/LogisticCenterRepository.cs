using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ShippingPlatform.DataBase.Repositories
{
    class LogisticCenterRepository
    {
        public LogisticCenter GetLogisticCenter(IDbConnection connection, int searchId)
        {
            return connection.Query<LogisticCenter>(
                "SELECT * FROM logistic_centers WHERE id_logistic_centers = @id",
                new { id = searchId }).FirstOrDefault();
        }

        public IEnumerable<LogisticCenter> GetAllLogisticCenters(IDbConnection connection)
        {
            return connection.Query<LogisticCenter>("SELECT * FROM logistic_centers").ToList();
        }
    }
}
