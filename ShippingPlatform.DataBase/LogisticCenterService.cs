using System.Collections.Generic;
using System.Data;

namespace ShippingPlatform.DataBase
{
    class LogisticCenterService
    {
        private LogisticCenterRepository lcRepository = new LogisticCenterRepository();
        public LogisticCenterMapper FindOneLogisticCenter(IDbConnection connection, int searchId)
        {
            return lcRepository.GetLogisticCenter(connection, searchId);
        }
        public IEnumerable<LogisticCenter> FindAllLogisticCenters(IDbConnection connection)
        {
            return lcRepository.GetAllLogisticCenters(connection);
        }
    }
}
