using System.Collections.Generic;
using System.Data;
using ShippingPlatform.DataBase.Repositories;

namespace ShippingPlatform.DataBase.Services
{
    public class NotificationService
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
