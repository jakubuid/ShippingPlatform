using System;
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
                Client client = new ClientService().FindOneClient(ConnectionProvider.GetConnection(), id);
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
                return Ok(new ClientService().FindAllClients(ConnectionProvider.GetConnection()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete([FromUri] int id)
        {
            try
            {
                new ClientService().DeleteClient(ConnectionProvider.GetConnection(), id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //add
        [HttpPost]
        public IHttpActionResult Post([FromBody] Client client)
        {
            try
            {
                new ClientService().AddClient(ConnectionProvider.GetConnection(), client);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //update
        [HttpPut]
        public IHttpActionResult Put([FromBody] Client client, int id)
        {
            try
            {
                new ClientService().UpdateClient(ConnectionProvider.GetConnection(), client, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}