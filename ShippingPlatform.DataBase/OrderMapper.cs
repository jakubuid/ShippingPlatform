using Dapper.FluentMap.Mapping;

namespace ShippingPlatform.DataBase
{
    class OrderMapper : EntityMap<Order>
    {
        public OrderMapper()
        {
            Map(x => x.id).ToColumn("id_oders");
            Map(x => x.recipientAddress).ToColumn("recipient_address");
            Map(x => x.clientAddress).ToColumn("client_address");
            Map(x => x.orderNumber).ToColumn("order_number");
            Map(x => x.createdDay).ToColumn("created_day");
            Map(x => x.pickUpDate).ToColumn("pick_up_date");
            Map(x => x.deliveryDate).ToColumn("delivery_date");
            Map(x => x.status).ToColumn("status");
        }
    }
}
