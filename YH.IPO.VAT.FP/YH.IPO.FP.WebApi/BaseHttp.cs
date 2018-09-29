using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using unirest_net.http;
using YH.IPO.FP.WebApi.Enum;
using YH.IPO.FP.WebApi.RespModel;

namespace YH.IPO.FP.WebApi
{
    public class BaseHttp
    {
        public static readonly List<string> RESULTCODE = new List<string> { "0", "1011", "4011", "5011", "6011", "3011", "4016", "8000" };
        public JObject DoGet(string url, Dictionary<string, object> paran, out bool success)
        {
            url += "?";
            paran.Each(x =>
            {
                if (x.Key != "SID")
                    url += $"{x.Key}={x.Value.ToJsonString().ToBase64ToGb2312()}&";
                else
                    url += $"{x.Key}={x.Value}&";
            });
            url = url.TrimEnd('&');
            var request = Unirest.get(url);
            HttpResponse<string> response;
            try
            {
                response = request.asString();
            }
            catch (AggregateException ex)
            {
                throw new AggregateException("本地服务未开启,请检查SOAP开票服务");
            }

            if (response.Code != 200)
                throw new HttpRequestException(response.Body);

            JObject obj = JsonConvert.DeserializeObject<JObject>(response.Body);

            var decode = Base64Decode(Encoding.GetEncoding("GB2312"), obj["ENCMSG"].ToString());

            var resp = JsonConvert.DeserializeObject<BaseRespModel>(decode);
            if (RESULTCODE.Contains(resp.retcode))
            {
                success = true;
            }
            else
            {
                success = false;
                throw new Exception(resp.retmsg);
            }
            var oboj = JsonConvert.DeserializeObject<JObject>(decode);
            if (resp.SID== SIDEnum.BatchDelivery)
            {
                oboj["responseMsg"] = oboj["responseMsg"].ToString().RewriteXML();
            }
            return oboj;
        }

        public static string Base64Decode(Encoding encodeType, string result)
        {
            string decode = string.Empty;
            byte[] bytes = Convert.FromBase64String(result.Replace("_", "+"));
            try
            {
                decode = encodeType.GetString(bytes);
            }
            catch
            {
                decode = result;
            }
            return decode;
        }
    }
}
