using Dapper.FluentMap.Mapping;

namespace ShippingPlatform.DataBase
{
    public class LogisticCenterMapper : EntityMap<LogisticCenter>
    {
        public LogisticCenterMapper()
        {
            Map(x => x.id).ToColumn("id_logistic_centers");
            Map(x => x.name).ToColumn("name");
            Map(x => x.logisticCenterAddress).ToColumn("logistic_center_address");
            Map(x => x.shippingRoute).ToColumn("shipping_route");
        }
    }
}
