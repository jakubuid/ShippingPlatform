using System;
using System.Web.Http;
using ShippingPlatform.DataBase;
using ShippingPlatform.DataBase.Services;

namespace WebService.Controllers
{
    public class LogisticCenterController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                LogisticCenterService logisticCenterService = new LogisticCenterService();
                return Ok(logisticCenterService.FindAllLogisticCenters(ConnectionProvider.GetConnection()));
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
                LogisticCenterService logisticCenterService = new LogisticCenterService();
                return Ok(logisticCenterService.FindOneLogisticCenter(ConnectionProvider.GetConnection(), id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}