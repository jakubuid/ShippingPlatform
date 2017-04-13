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
            return connection.Query<Notification, Order, Address, Address, Notification>(
                @"SELECT * FROM notifications
                INNER JOIN orders o ON notifications.id_order = o.id_orders
                INNER JOIN addresses a3 ON o.id_client_address = a3.id_addresses
                INNER JOIN addresses a2 ON o.id_recipient_address = a2.id_addresses
                WHERE id_notifications = @id",
                (notifications, order, orderRecipientAddress, orderClientAddress) =>
                {
                    notifications.order = order;
                    order.clientAddress = orderClientAddress;
                    order.recipientAddress = orderRecipientAddress;
                    return notifications;
                },
                new {id = searchId}, splitOn: "id_orders, id_addresses, id_addresses").FirstOrDefault();
        }

        public IEnumerable<Notification> GetAllNotifications(IDbConnection connection)
        {
            return connection.Query<Notification, Order, Address, Address, Notification>(
                @"SELECT * FROM notifications
                INNER JOIN orders o ON notifications.id_order = o.id_orders
                INNER JOIN addresses a3 ON o.id_client_address = a3.id_addresses
                INNER JOIN addresses a2 ON o.id_recipient_address = a2.id_addresses",
                (notifications, order, orderRecipientAddress, orderClientAddress) =>
                {
                    notifications.order = order;
                    order.clientAddress = orderClientAddress;
                    order.recipientAddress = orderRecipientAddress;
                    return notifications;
                }, splitOn: "id_orders, id_addresses, id_addresses"
            ).ToList();
        }
    }
}