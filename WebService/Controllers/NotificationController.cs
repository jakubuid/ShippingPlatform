using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShippingPlatform;
using ShippingPlatform.DataBase;
using ShippingPlatform.DataBase.Services;

namespace WebService.Controllers
{
    public class NotificationController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                NotificationService notificationService = new NotificationService();
                return Ok(notificationService.FindAllNotifications(ConnectionProvider.GetConnection()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                Notification notification = new NotificationService().FindOneNotification(ConnectionProvider.GetConnection(), id);
                return Ok(notification);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
