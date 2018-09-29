using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http.Filters;

namespace YH.IPO.FP.WebApi
{
    public class APIResult
    {
        public int Code { get; set; }
        public object Result { get; set; }
        public string Message { get; set; }

        public APIResult()
        {

        }

        public APIResult(int code, string message, object result)
        {
            this.Code = code;
            this.Message = message;
            this.Result = result;
        }
    }

    public class APIException : Exception
    {
        public APIException(string message)
            : base(message)
        {
            this.HResult = 1;
        }
        public APIException(int code, string message)
            : base(message)
        {
            this.HResult = code;
        }
        public APIException(int code, string message, Exception ex)
            : base(message, ex)
        {
            this.HResult = code;
        }
    }

    /// <summary>
    /// OnAction 重写 固定统一返回值
    /// </summary>
    public class WebApiResultAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext context)
        {
            //base.OnActionExecuted(context);
            var content = context.Response?.Content as ObjectContent;
            if (content != null)
            {
                content.Value = new APIResult
                {
                    Result = content.Value,
                };
            }

            // 设置发生异常时的消息
            if (context.Exception != null)
            {
                var exceptionResult = new APIResult(context.Exception.HResult < 0 ? 1 : context.Exception.HResult, context.Exception.Message, null);
                context.Response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(exceptionResult), Encoding.UTF8, "application/json")
                };
            }
        }
    }
}
