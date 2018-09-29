using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using YH.IPO.FP.WebApi.Enum;

namespace YH.IPO.FP.WebApi.Controllers
{
    [WebApiResult]
    public class InvoiceRequestController : ApiController
    {
        [HttpPost]
        public dynamic RequestVat([FromBody]RequestModel model)
        {

            var url = ConfigurationManager.AppSettings["url"];
            if (string.IsNullOrWhiteSpace(url))
                throw new Exception("config.配置信息为空[url]");
                //return Json(new { Success = false, Msg = "config.配置信息为空[url]" });

            if (model == null)
                return Json(new { Success = false, Msg = "提交信息为空,请检查提交信息" });

            if (string.IsNullOrWhiteSpace(model.Json))
                return Json(new { Success = false, Msg = "提交信息Json为空,请检查提交信息" });

            //Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var sin = Extend.FindAllClass<IBaseInvoice>();

            var type = sin.FirstOrDefault(x => x.SID == model.SID);

            if (type == null)
                return Json(new { Success = false, Msg = "未找到对应的开票类型" });

            type.DescType(model.Json);
            bool result = false;
            var str = new BaseHttp().DoGet(url, new Dictionary<string, object>
            {
                ["SID"] = model.SID.GetHashCode().ToString(),
                ["SIDParam"] = JsonConvert.DeserializeObject<JObject>(model.Json)
            }, out result);
            return Json(new { Success = result, Result = str });

        }
    }
    public class RequestModel
    {
        public SIDEnum SID { get; set; }

        public string Json { get; set; }
    }
}
