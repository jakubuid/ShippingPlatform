using Dapper.FluentMap.Mapping;

namespace ShippingPlatform.DataBase
{
    class ClientMapper : EntityMap<Client>
    {
        public ClientMapper()
        {
            Map(x => x.id).ToColumn("id_clients");
        }
    }
}
