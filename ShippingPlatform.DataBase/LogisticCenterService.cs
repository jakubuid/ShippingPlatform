using System.Collections.Generic;
using System.Data;

namespace ShippingPlatform.DataBase
{
    public class LogisticCenterService
    {
        private LogisticCenterRepository lcRepository = new LogisticCenterRepository();
        public LogisticCenter FindOneLogisticCenter(IDbConnection connection, int searchId)
        {
            return lcRepository.GetLogisticCenter(connection, searchId);
        }
        public IEnumerable<LogisticCenter> FindAllLogisticCenters(IDbConnection connection)
        {
            return lcRepository.GetAllLogisticCenters(connection);
        }
    }
}
