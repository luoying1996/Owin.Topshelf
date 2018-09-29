using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;

namespace TopShelf.IPO.FP.Extenion
{
    public class HttpControllerExtension
    {
        /// <summary>
        /// 
        /// </summary>
        public HttpControllerDescriptor ControllerDescriptor { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Action { get; set; }
    }
}
