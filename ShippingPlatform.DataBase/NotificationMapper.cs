using Dapper.FluentMap.Mapping;

namespace ShippingPlatform.DataBase
{
    class NotificationMapper : EntityMap<Notification>
    {
        public NotificationMapper()
        {
            Map(x => x.id).ToColumn("id_notifications");
            Map(x => x.clientEmail).ToColumn("client_email");
            Map(x => x.recipientEmail).ToColumn("recipient_email");
            Map(x => x.message).ToColumn("message");
            Map(x => x.subject).ToColumn("subject");
            Map(x => x.timeStamp).ToColumn("time_stamp");
            Map(x => x.order).ToColumn("order");
            Map(x => x.attachmentId).ToColumn("attachment");
        }
    }
}
