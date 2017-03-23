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
        public IHttpActionResult GetAll()
        {
            ClientService clientService = new ClientService();
            return Ok(clientService.FindAllClients(ConnectionProvider.GetConnection()));
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            ClientService clientService = new ClientService();
            Client client = clientService.FindOneClient(ConnectionProvider.GetConnection(), id);
            return Ok(client);
        }

        [HttpGet]
        public IHttpActionResult Search(string searchTerm)
        {
            ClientService clientService = new ClientService();
            return Ok(clientService.FindAllClients(ConnectionProvider.GetConnection()));
        }

        [HttpDelete]
        public IHttpActionResult Delete([FromUri]int id)
        {
            return Ok();
        }

        //put update
        //post insert
        [HttpPost]
        public IHttpActionResult Save([FromBody] Client client)
        {
            try
            {
                //new ClientService().Save(); dodaj metode w servisie ktora dodaje clienta 
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}