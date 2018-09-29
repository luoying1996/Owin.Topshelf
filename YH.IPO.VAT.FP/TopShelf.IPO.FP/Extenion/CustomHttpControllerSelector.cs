using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;

namespace TopShelf.IPO.FP.Extenion
{
    public class CustomHttpControllerSelector : DefaultHttpControllerSelector
    {
        private readonly ConcurrentDictionary<string, HttpControllerExtension> mapping;
        private readonly string actionKey = "action";
        private readonly string aliasKey = "aliasname";

        public CustomHttpControllerSelector(HttpConfiguration config) : base(config)
        {
            mapping = config.Controllers();

        }
        /// <summary>
        /// 查找控制器
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            IHttpRouteData routeData = request.GetRouteData();
            if (mapping.Count > 0 && routeData != null && routeData.Values.ContainsKey(actionKey))
            {
                var alias = routeData.Values[actionKey]?.ToString();
                if (!string.IsNullOrWhiteSpace(alias) && mapping.ContainsKey(alias))
                {
                    request.GetRouteData().Values[actionKey] = mapping[alias].Action;
                    request.Properties.Add(aliasKey, alias);//赋值别名
                    return mapping[alias].ControllerDescriptor;
                }
            }

            return base.SelectController(request);
        }

    }
}
