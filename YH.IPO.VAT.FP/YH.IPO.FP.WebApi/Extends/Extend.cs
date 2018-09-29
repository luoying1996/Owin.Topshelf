using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;

namespace YH.IPO.FP.WebApi
{
    public static class Extend
    {
        public static string ToJsonString<T>(this T obj)
            where T : class
        {
            try
            {
                return JsonConvert.SerializeObject(obj);
            }
            catch (Exception ex)
            {
                throw new Exception("序列化数据异常");
            }
        }

        public static void Each<T>(this IEnumerable<T> enumber, Action<T> action)
        {
            foreach (var item in enumber)
            {
                action.Invoke(item);
            }
        }

        public static string ToBase64ToGb2312(this string value)
        {
            byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(value);
            return Convert.ToBase64String(bytes).Replace("+", "_");
        }

        public static string ToBase64Gb2312(this string value)
        {
            byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(value);
            return Convert.ToBase64String(bytes);
        }


        public static List<T> FindClasses<T>() where T : class
        {
            List<T> typeList = new List<T>();
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (var type in types)
            {
                if (typeof(T).IsAssignableFrom(type) && !type.IsAbstract && !type.IsInterface)
                {
                    T instance = Activator.CreateInstance(type) as T;
                    typeList.Add(instance);
                }
            }
            return typeList;
        }

        public static List<T> FindAllClass<T>() where T : class
        {
            List<T> typeList = new List<T>();
            Assembly[] assemblies2 = AppDomain.CurrentDomain.GetAssemblies();
            for (int i = 0; i < assemblies2.Length; i++)
            {
                Assembly assembly = assemblies2[i];
                Type[] types = assembly.GetTypes();
                foreach (var type in types)
                {
                    if (typeof(T).IsAssignableFrom(type) && !type.IsAbstract && !type.IsInterface)
                    {
                        T instance = Activator.CreateInstance(type) as T;
                        typeList.Add(instance);
                    }
                }
            }
            return typeList;
        }

        public static void IsValid<T>(this T model)
            where T : class
        {
            var validationContext = new ValidationContext(model);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(model, validationContext, results, true);

            if (!isValid)
            {
                throw new Exception(string.Format("数据校验异常：{0}",
                    string.Join(",", results.Select(x => x.ErrorMessage))));
            }
        }

        public static string RewriteXML(this string xml)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                var xn = doc.SelectSingleNode("FPXT_COM_OUTPUT");
                if (xn != null)
                {
                    return BaseHttp.Base64Decode(Encoding.GetEncoding("GB2312"), xn["DATA"].InnerText);
                }
                return "";
            }
            catch (Exception ex)
            {
                throw new Exception("解析返回xml格式错误" + ex.Message);
            }
        }
    }
}
