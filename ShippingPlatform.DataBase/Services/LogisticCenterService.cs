using System.Collections.Generic;
using System.Data;
using ShippingPlatform.DataBase.Repositories;

namespace ShippingPlatform.DataBase.Services
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
