using System;
using System.Web.Http;
using ShippingPlatform;
using ShippingPlatform.DataBase;
using ShippingPlatform.DataBase.Services;

namespace WebService.Controllers
{
    public class PackageController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                PackageService packageService = new PackageService();
                return Ok(packageService.FindAllPackages(ConnectionProvider.GetConnection()));
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
                Package package = new PackageService().FindOnePackage(ConnectionProvider.GetConnection(), id);
                return Ok(package);
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
                new PackageService().DeletePackage(ConnectionProvider.GetConnection(), id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] Package package)
        {
            try
            {
                new PackageService().AddPackage(ConnectionProvider.GetConnection(), package);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //update
        [HttpPut]
        public IHttpActionResult Put([FromBody] Package package, int id)
        {
            try
            {
                new PackageService().UpdatePackage(ConnectionProvider.GetConnection(), package, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}