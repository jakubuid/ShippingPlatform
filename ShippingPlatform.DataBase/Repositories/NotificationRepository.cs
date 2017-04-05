using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ShippingPlatform.DataBase.Repositories
{
    class NotificationRepository
    {
        public Notification GetNotification(IDbConnection connection, int searchId)
        {
            return connection.Query<Notification, Order, Notification>(
                @"SELECT * FROM notifications
                INNER JOIN orders o ON notifications.id_order = o.id_orders
                WHERE id_notifications = @id",
                (notifications, order) =>
                {
                    notifications.order = order;
                    return notifications;
                },
                new {id = searchId}, splitOn: "id_orders").FirstOrDefault();
        }

        public IEnumerable<Notification> GetAllNotifications(IDbConnection connection)
        {
            return connection.Query<Notification, Order, Notification>(
                @"SELECT * FROM notifications
                 INNER JOIN orders o ON notifications.id_order = o.id_orders",
                (notifications, orderTmp) =>
                {
                    notifications.order = orderTmp;
                    return notifications;
                }, splitOn: "id_orders"
            ).ToList();
        }
    }
}