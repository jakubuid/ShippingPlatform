using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShippingPlatform;
using ShippingPlatform.DataBase;

namespace WebService.Controllers
{
    public class ClientController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetClients()
        {
           ClientService clientService = new ClientService();
            return Ok(clientService.FindAllClients(ConnectionProvider.GetConnection()));
        }
    }
}
