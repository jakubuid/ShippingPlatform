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
    public class AddressController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                AddressService addressService = new AddressService();
                return Ok(addressService.FindAllAddresses(ConnectionProvider.GetConnection()));
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
                Address address = new AddressService().FindOneAddress(ConnectionProvider.GetConnection(), id);
                return Ok(address);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //add
        [HttpPost]
        public IHttpActionResult Post([FromBody] Address address)
        {
            try
            {
                new AddressService().AddAddress(ConnectionProvider.GetConnection(), address);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //update
        [HttpPut]
        public IHttpActionResult Put([FromBody] Address address, int id)
        {
            try
            {
                new AddressService().UpdateAddress(ConnectionProvider.GetConnection(), address, id);
                return Ok();
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
                new AddressService().DeleteAddress(ConnectionProvider.GetConnection(), id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}