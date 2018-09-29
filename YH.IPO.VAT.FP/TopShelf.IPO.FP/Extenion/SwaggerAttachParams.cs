using Swashbuckle.Swagger; 
using System.Collections.Concurrent;
using System.Collections.Generic; 

namespace TopShelf.IPO.FP
{
    public class SwaggerAttachParams
    {
        /// <summary>
        /// key=参数名称,value=参数定义
        /// </summary>
        static ConcurrentDictionary<string, Parameter> param = new ConcurrentDictionary<string, Parameter>();

        /// <summary>
        /// 给Swagger附加自定义参数
        /// </summary>
        /// <param name="name">参数名称</param>
        /// <param name="postion">参数位置[header、query]</param>
        /// <param name="required">是否必填</param>
        /// <param name="type">参数类型[string、int等]</param>
        /// <param name="description">参数描述</param>
        /// <param name="reference">参数引用</param>
        public static void Add(string name, string postion = "header", bool required = false, string type = "string", string description = null, string reference = null)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(postion)) return;
            if (!param.ContainsKey(name))
            {
                param.TryAdd(name, new Parameter { name = name, @in = postion, description = description, required = required, type = type });
            }
            else
            {
                param[name] = new Parameter { name = name, @in = postion, description = description, required = required, type = type };
            }
        }
        /// <summary>
        /// 读取Swagger附加自定义参数
        /// </summary>
        public static IEnumerable<Parameter> Parameters
        {
            get { return param.Values; }
        }
    }
}
