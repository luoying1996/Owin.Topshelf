using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using TopShelf.IPO.FP.IOC;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(AutofacConfig), "Initialize")]
namespace TopShelf.IPO.FP.IOC
{
    public static class AutofacConfig
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        public static void Initialize(HttpConfiguration config)
        {
            Container = RegisterServices(Builder);
            config.DependencyResolver = new AutofacWebApiDependencyResolver(Container);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        private static IContainer RegisterServices(ContainerBuilder builder)
        {

            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetEntryAssembly());
            //builder.Register(c => new CacheService()).SingleInstance();
            //foreach (var instance in instances)
            //{
            //    //builder.Register(c => instance).SingleInstance();
            //    builder.RegisterType(instance).SingleInstance();
            //}
            //builder.Register((c) => new Dispatcher((CacheService)c.ResolveOptional(typeof(CacheService)))).SingleInstance();
            return builder.Build();
        }

        public static ContainerBuilder Builder { get; } = new ContainerBuilder();
        public static IContainer Container { get; private set; }
    }

}
