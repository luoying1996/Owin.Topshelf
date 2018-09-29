using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using YH.IPO.FP.WebApi;

namespace TopShelf.IPO.FP.Filter
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        /// <summary>
        /// 捕获异常处理
        /// </summary>
        /// <param name="context"></param>
        public override void Handle(ExceptionHandlerContext context)
        {
            var exceptionResult = new APIResult(1, context.Exception is InvalidOperationException ? "接口未实现或无效接口" : context.Exception.Message, null);
            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(exceptionResult), Encoding.UTF8, "application/json")
            };

            context.Result = new GlobalExceptionResult() { Request = context.Request, Response = result };

        }

        /// <summary>
        /// 
        /// </summary>
        private class GlobalExceptionResult : IHttpActionResult
        {
            public HttpRequestMessage Request { get; set; }

            public HttpResponseMessage Response { get; set; }

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                return Task.FromResult(Response);
            }
        }
    }

}
