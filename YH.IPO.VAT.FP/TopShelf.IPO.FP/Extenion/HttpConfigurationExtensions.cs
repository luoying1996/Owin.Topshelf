using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace TopShelf.IPO.FP.Extenion
{
    public static class HttpConfigurationExtensions
    {
        public static ConcurrentDictionary<string, HttpControllerExtension> Controllers(this HttpConfiguration config)
        {
            ConcurrentDictionary<string, HttpControllerExtension> mapping = new ConcurrentDictionary<string, HttpControllerExtension>(StringComparer.OrdinalIgnoreCase);
            //获取服务的程序集
            var assemblies = config.Services.GetAssembliesResolver();
            //获取控制器
            var controllerResolver = config.Services.GetHttpControllerTypeResolver();
            var controllerTypes = controllerResolver.GetControllerTypes(assemblies);
            var controllerLength = DefaultHttpControllerSelector.ControllerSuffix.Length;

            //加载程序集       
            var assembly = Assembly.Load("YH.IPO.FP.WebApi");
            //获取程序集下所有的类，通过Linq筛选继承IController类的所有类型     
            var lst = assembly.GetTypes().Where(type => typeof(System.Web.Mvc.IController).IsAssignableFrom(type));
            foreach (var item in lst)
            {
                controllerTypes.Add(item);
            }


            foreach (var objType in controllerTypes)
            {
                var controllerName = objType.Name.Remove(objType.Name.Length - controllerLength);
                MethodInfo[] Methods = objType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
                foreach (MethodInfo Method in Methods)
                {
                    if (Method.GetCustomAttributes(typeof(AliasNameAttribute), false).Length > 0)
                    {
                        var actionName = (ActionNameAttribute)Method.GetCustomAttributes(typeof(ActionNameAttribute), false)?.FirstOrDefault();
                        var action = actionName != null ? actionName.Name : Method.Name;
                        var attributes = Method.GetCustomAttributes(typeof(AliasNameAttribute), false);
                        foreach (AliasNameAttribute attribute in attributes)
                        {
                            if (!mapping.ContainsKey(attribute.Alias))
                            {
                                var controllerDescriptor = new HttpControllerDescriptor(config, objType.Name, objType);
                                mapping.TryAdd(attribute.Alias, new HttpControllerExtension() { ControllerDescriptor = controllerDescriptor, Action = action });
                            }

                        }
                    }
                    else
                    {
                        var controllerDescriptor = new HttpControllerDescriptor(config, objType.Name, objType);
                        mapping.TryAdd(Method.Name, new HttpControllerExtension() { ControllerDescriptor = controllerDescriptor, Action = Method.Name });
                    }
                }
            }

            return mapping;
        }
    }
}
