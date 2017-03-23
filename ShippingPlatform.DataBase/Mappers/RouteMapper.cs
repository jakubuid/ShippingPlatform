using Dapper.FluentMap.Mapping;

namespace ShippingPlatform.DataBase.Mappers
{
    class RouteMapper : EntityMap<Route>
    {
        public RouteMapper()
        {
            Map(x => x.id).ToColumn("id_routes");
            Map(x => x.startAddressId).ToColumn("id_start_address");
            Map(x => x.endAddressId).ToColumn("id_end_address");
            Map(x => x.startTime).ToColumn("start_time");
            Map(x => x.endTime).ToColumn("end_time");
            Map(x => x.orderId).ToColumn("id_order");
        }
    }
}
