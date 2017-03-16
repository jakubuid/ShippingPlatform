using Dapper.FluentMap.Mapping;

namespace ShippingPlatform.DataBase
{
    class RouteMapper : EntityMap<Route>
    {
        public RouteMapper()
        {
            Map(x => x.id).ToColumn("id_routes");
            Map(x => x.startAddress).ToColumn("start_address");
            Map(x => x.endAddress).ToColumn("end_address");
            Map(x => x.startTime).ToColumn("start_time");
            Map(x => x.endTime).ToColumn("end_time");
        }
    }
}
