using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace YH.IPO.FP.WebApi.Controllers
{
    [WebApiResult]
    public class DemoApiController : ApiController
    {
        public string Test()
        {
            return "OK";
        }
    }
}
