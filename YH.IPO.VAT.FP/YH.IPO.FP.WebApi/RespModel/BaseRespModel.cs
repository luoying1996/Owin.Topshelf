
using YH.IPO.FP.WebApi.Enum;

namespace YH.IPO.FP.WebApi.RespModel
{
    public class BaseRespModel
    {
        // 0调用成功 3011 ,4011 , 5011-打印成功  6011-发票作废成功  1011 表示启动开票服务成功 0表示关闭成功 8000：上传成功
        //返回码 4011 或 4016,	"开票成功" 其它失败
        public string retcode { get; set; }

        public SIDEnum SID { get; set; }

        public string retmsg { get; set; }

        //public string responseMsg { get; set; }

    }
}
