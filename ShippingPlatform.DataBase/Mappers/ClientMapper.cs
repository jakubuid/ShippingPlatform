using Dapper.FluentMap.Mapping;

namespace ShippingPlatform.DataBase.Mappers
{
    class ClientMapper : EntityMap<Client>
    {
        public ClientMapper()
        {
            Map(x => x.id).ToColumn("id_clients");
            Map(x => x.clientAddressId).ToColumn("id_client_address");
            Map(x => x.orderId).ToColumn("id_order");
            Map(x => x.login).ToColumn("login");
            Map(x => x.password).ToColumn("password");
            Map(x => x.addressEmail).ToColumn("address_email");
        }
    }
}
