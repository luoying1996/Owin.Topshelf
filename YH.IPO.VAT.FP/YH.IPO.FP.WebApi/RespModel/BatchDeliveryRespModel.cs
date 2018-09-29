
namespace YH.IPO.FP.WebApi.RespModel
{
    public class BatchDeliveryRespModel : BaseRespModel
    {
        // 正常返回时，responeseMsg返回的报文参考如下：
        //<?xml version = "1.0" encoding="GBK"?>
        //<FPXT_COM_OUTPUT>
        //	<ID>0400</ID>ID与传入的对应
        //<CODE>0000</CODE>是错误代码， 0000 成功
        //<MESS>成功</MESS>为错误信息，
        //	<DATA>base64(返回内容的 XML结构体)</DATA>为返回的数据 没有就是空
        //</FPXT_COM_OUTPUT>
        public string responseMsg { get; set; }
        //public string retcode { get; set; }
        //public SIDEnum SID { get => SIDEnum.BatchDelivery; }
        //public string retmsg { get; set; }

    }
}
