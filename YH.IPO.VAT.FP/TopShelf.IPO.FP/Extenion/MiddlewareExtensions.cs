using Owin;
using System;

namespace TopShelf.IPO.FP.Extenion
{
    public static class MiddlewareExtensions
    {
        private static Action<IAppBuilder> middlewares = null;

        internal static void UseMiddleware(this IAppBuilder appBuilder)
        {
            if (middlewares != null)
            {
                middlewares.Invoke(appBuilder);
            }
        }

        /// <summary>
        /// 注册中间件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        public static void Use(Action<IAppBuilder> action)
        {
            middlewares = action;
        }
    }

}
