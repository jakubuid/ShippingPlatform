using Dapper.FluentMap.Mapping;

namespace ShippingPlatform.DataBase.Mappers
{
    class AddressMapper : EntityMap<Address>
    {
        public AddressMapper()
        {
            Map(x => x.id).ToColumn("id_addresses");
            Map(x => x.country).ToColumn("country");
            Map(x => x.city).ToColumn("city");
            Map(x => x.zipcode).ToColumn("zipcode");
            Map(x => x.houseNumber).ToColumn("house_number");
        }
    }
}
