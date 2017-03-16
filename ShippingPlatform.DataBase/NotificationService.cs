
using System.Collections.Generic;
using System.Data;

namespace ShippingPlatform.DataBase
{
    class NotificationService
    {
        private NotificationRepository notificationRepo = new NotificationRepository();
        public Notification FindOneNotification(IDbConnection connection, int searchId)
        {
            return notificationRepo.GetNotification(connection, searchId);
        }

        public IEnumerable<Notification> FindAllNotifications(IDbConnection connection)
        {
            return notificationRepo.GetAllNotifications(connection);
        }
    }
}
