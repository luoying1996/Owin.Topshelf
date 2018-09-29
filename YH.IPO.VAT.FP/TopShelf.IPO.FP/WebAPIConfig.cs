using Newtonsoft.Json.Serialization;
using Owin;
using Swashbuckle.Application;
using System;
using System.Diagnostics;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Dispatcher;
using System.Web.Http.ExceptionHandling;
using TopShelf.IPO.FP.Extenion;
using TopShelf.IPO.FP.Filter;
using TopShelf.IPO.FP.IOC;

namespace TopShelf.IPO.FP
{
    public class WebAPIConfig
    {
        public HttpConfiguration Config { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            var config = ConfigureApi();
            app.UseStaticFiles();
            app.UseMiddleware();
            app.UseWebApi(config);
        }

        private HttpConfiguration ConfigureApi()
        {
            Config = new HttpConfiguration();

            Config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new DefaultContractResolver() { IgnoreSerializableAttribute = true };
            Config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            Config.Formatters.JsonFormatter.MediaTypeMappings.Add(new QueryStringMapping("datatype", "json", "application/json"));
            Config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(
                new Newtonsoft.Json.Converters.IsoDateTimeConverter()
                {
                    DateTimeFormat = "yyyy-MM-dd HH:mm:ss"
                }
            );

            //Swagger配置
            var name = "YH.IPO.FP.WebApi";// Process.GetCurrentProcess().ProcessName;

            if (Debugger.IsAttached)
            {
                Config.EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", $"{name}的API文档");
                    c.IncludeXmlComments($@"{AppDomain.CurrentDomain.BaseDirectory}\{name}.XML");
                    c.OperationFilter<GlobalHttpHeaderFilter>();
                }).EnableSwaggerUi();
            }
            //跨域配置
            Config.EnableCors(new EnableCorsAttribute("*", "*", "*") { SupportsCredentials = true });
            Config.MapHttpAttributeRoutes();
            Config.Routes.MapHttpRoute(
                "DefaultApi",
                "{controller}/{action}/{id}",
                new { id = RouteParameter.Optional });

            Config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            //Config.Formatters.Clear();  //注释,添加这个会出现 406 的错误 把所有的Response 的东西清空了Response.Context == null
            AutofacConfig.Initialize(Config);

            #region 格式化json 清除 json为NULL的字符串
            //var json = new JsonMediaTypeFormatter();
            //json.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            #endregion

            Config.Filters.UseFilters();

            Config.Services.Replace(typeof(IHttpControllerSelector), new CustomHttpControllerSelector(Config));
            Config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());
            return Config;
        }
    }
}
