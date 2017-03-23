using Dapper.FluentMap.Mapping;

namespace ShippingPlatform.DataBase.Mappers
{
    public class LogisticCenterMapper : EntityMap<LogisticCenter>
    {
        public LogisticCenterMapper()
        {
            Map(x => x.id).ToColumn("id_logistic_centers");
            Map(x => x.name).ToColumn("name");
            Map(x => x.logisticCenterAddressId).ToColumn("id_logistic_center_address");
            Map(x => x.shippingRouteId).ToColumn("id_shipping_route");
        }
    }
}
