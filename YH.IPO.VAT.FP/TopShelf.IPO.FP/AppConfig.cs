using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace TopShelf.IPO.FP
{
    public class AppConfig
    {
        public static AppConfig Default { get; private set; }
        static AppConfig()
        {
            Default = Load<AppConfig>();
            //增加前缀
            AppLogger.Info($"服务前缀为：{Default.ServicePrefix}");
            if (!string.IsNullOrEmpty(Default.ServicePrefix))
            {
                Default.ServiceName = $"{Default.ServicePrefix}_{Default.ServiceName}";
                Default.DisplayName = $"{Default.ServicePrefix}_{Default.DisplayName}";
            }
        }

        public AppConfig()
        {
            var name = Process.GetCurrentProcess().ProcessName;
            this.ServiceName = this.ServiceName ?? name;
            this.Description = this.Description ?? name;
            this.DisplayName = this.DisplayName ?? name;
        }

        /// <summary>
        /// 服务名称前缀，用于标识一类服务，显示名称为:{ServicePrefix}_{ServiceName}
        /// </summary>
        public string ServicePrefix { get; set; }
        /// <summary>
        /// 服务的描述信息
        /// </summary>
        public string ServiceName { get; set; }
        /// <summary>
        /// 服务的显示名称
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// 服务的名称
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 设置该值时，表示开启WebAPI服务
        /// </summary>
        public int HttpPort { get; set; }

        public static T Load<T>() where T : AppConfig
        {
            var config = Load<T>("config.json");
            return config;
        }
        public static T Load<T>(string path)
        {
            bool flag = path.StartsWith("http://") || path.StartsWith("https://");
            T result;
            if (flag)
            {
                result = LoadFromUrl<T>(path);
            }
            else
            {
                result = LoadFromFile<T>(path);
            }
            return result;
        }
        private static T LoadFromFile<T>(string filename)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string path = string.Format("{0}\\{1}", baseDirectory, filename);
            T cur = default(T);
            T parent = default(T);
            bool flag = File.Exists(path);
            if (flag)
            {
                string text = File.ReadAllText(path);
                cur = JsonConvert.DeserializeObject<T>(text);
            }
            DirectoryInfo directoryInfo = new DirectoryInfo(baseDirectory);
            string fullName = directoryInfo.Parent.FullName;
            string path2 = string.Format("{0}\\{1}", fullName, filename);
            bool flag2 = File.Exists(path2);
            if (flag2)
            {
                string text2 = File.ReadAllText(path2);
                parent = JsonConvert.DeserializeObject<T>(text2);
            }
            return JoinConfig<T>(cur, parent);
        }
        private static T JoinConfig<T>(T cur, T parent)
        {
            bool flag = cur == null;
            T result;
            if (flag)
            {
                result = default(T);
            }
            else
            {
                bool flag2 = parent == null;
                if (flag2)
                {
                    result = cur;
                }
                else
                {
                    PropertyInfo[] properties = typeof(T).GetProperties();
                    for (int i = 0; i < properties.Length; i++)
                    {
                        PropertyInfo propertyInfo = properties[i];
                        object value = propertyInfo.GetValue(cur);
                        bool flag3 = value == null;
                        if (flag3)
                        {
                            object value2 = propertyInfo.GetValue(parent);
                            propertyInfo.SetValue(propertyInfo, value2);
                        }
                    }
                    result = cur;
                }
            }
            return result;
        }
        private static T LoadFromUrl<T>(string url)
        {
            T cur = default(T);
            T parent = default(T);
            string text = DownLoad(url);
            bool flag = !string.IsNullOrEmpty(text);
            if (flag)
            {
                cur = JsonConvert.DeserializeObject<T>(text);
            }
            Uri uri = new Uri(url);
            string text2 = "";
            for (int i = 0; i < uri.Segments.Length - 2; i++)
            {
                text2 += uri.Segments[i];
            }
            text2 += uri.Segments.Last<string>();
            string url2 = string.Format("{0}://{1}/{2}", uri.Scheme, uri.Host, text2);
            string text3 = DownLoad(url2);
            bool flag2 = !string.IsNullOrEmpty(text3);
            if (flag2)
            {
                parent = JsonConvert.DeserializeObject<T>(text3);
            }
            return JoinConfig<T>(cur, parent);
        }
        private static string DownLoad(string url)
        {
            HttpClient httpClient = new HttpClient();
            Task<HttpResponseMessage> async = httpClient.GetAsync(url);
            HttpResponseMessage result = async.Result;
            Task<string> task = result.Content.ReadAsStringAsync();
            bool flag = result.StatusCode == HttpStatusCode.OK;
            string result3;
            if (flag)
            {
                string result2 = task.Result;
                result3 = result2;
            }
            else
            {
                result3 = null;
            }
            return result3;
        }
    }
}
