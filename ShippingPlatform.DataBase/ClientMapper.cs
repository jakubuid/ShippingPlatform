using Dapper.FluentMap.Mapping;

namespace ShippingPlatform.DataBase
{
    class ClientMapper : EntityMap<Client>
    {
        public ClientMapper()
        {
            Map(x => x.id).ToColumn("id_clients");
            Map(x => x.clientAddress).ToColumn("client_address");
            Map(x => x.order).ToColumn("order");
            Map(x => x.login).ToColumn("login");
            Map(x => x.password).ToColumn("password");
            Map(x => x.addressEmail).ToColumn("address_email");
        }
    }
}
