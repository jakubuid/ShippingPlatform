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
    public class ClientController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                ClientService clientService = new ClientService();
                return Ok(clientService.FindAllClients(ConnectionProvider.GetConnection()));
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
                ClientService clientService = new ClientService();
                Client client = clientService.FindOneClient(ConnectionProvider.GetConnection(), id);
                return Ok(client);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult Search(string searchTerm)
        {
            try
            {
                ClientService clientService = new ClientService();
                return Ok(clientService.FindAllClients(ConnectionProvider.GetConnection()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete([FromUri]int id)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
               return BadRequest(ex.Message);
            }
        }
        //delete
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