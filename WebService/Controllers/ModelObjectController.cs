using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebService.Controllers
{
    public abstract class ModelObjectController<T> : ApiController //where T : DomaniObject
    {
    }
}