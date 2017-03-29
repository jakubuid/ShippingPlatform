﻿using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ShippingPlatform.DataBase.Repositories
{
    class NotificationRepository
    {
        public Notification GetNotification(IDbConnection connection, int searchId)
        {
            return connection.Query<Notification>(
                "SELECT * FROM notifications WHERE id_notifications = @id",
                new { id = searchId }).FirstOrDefault();
        }
        public IEnumerable<Notification> GetAllNotifications(IDbConnection connection)
        {
            return connection.Query<Notification>("SELECT * FROM notifications").ToList();
        }
    }
}