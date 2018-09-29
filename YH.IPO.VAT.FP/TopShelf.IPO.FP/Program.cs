using Autofac;
using Owin;
using TopShelf.IPO.FP.Extenion;
using TopShelf.IPO.FP.IOC;

namespace TopShelf.IPO.FP
{
    class Program
    {
        static void Main(string[] args)
        {
            AppServer.Run(AppConfig.Default, () =>
            {
                //Config config = AppConfig.Load<Config>();
                AppLogger.Info("Server Start.");

                #region 调试模式下给Swagger附加参数

                 //SwaggerAttachParams.Add("appId", "header");  //TODO

                #endregion

                //使用OwinContext 中间件

                MiddlewareExtensions.Use(app => { app.Use<OwinContextMiddleware>(); });

                //允许JSON输出驼峰格式化
                //JsonConfig.SetCamelCase(true);
                //OwinContext.Current.Request.Accept = "text/html, application/xhtml+xml, */*";
                //注入 //TODO
                //AutofacConfig.Builder.Register<string>(c =>
                //{
                //    return OwinContext.Current.Request.Headers.Get("appId") ?? string.Empty;
                //}).As<string>().InstancePerRequest();


                //AutofacConfig.Builder.RegisterType(typeof(Logger)).SingleInstance();


            }, () =>
            {
                AppLogger.Info("Server Stop.");
            });
        }
    }
}
