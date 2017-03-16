using Dapper.FluentMap.Mapping;

namespace ShippingPlatform.DataBase
{
    class PackageMapper : EntityMap<Package>
    {
        public PackageMapper()
        {
            Map(x => x.id).ToColumn("id_packages");
            Map(x => x.height).ToColumn("height");
            Map(x => x.width).ToColumn("width");
            Map(x => x.depth).ToColumn("depth");
            Map(x => x.weight).ToColumn("weight");
            Map(x => x.content).ToColumn("content");
        }
    }
}
