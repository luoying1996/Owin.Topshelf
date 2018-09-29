 

namespace YH.IPO.FP.WebApi.RespModel
{
    public class InvoiceQueryUpdateRespModel : BaseRespModel
    {
        //public string retcode { get; set; }
        //public SIDEnum SID { get => SIDEnum.InvoiceQueryUpdate; }
        //public string retmsg { get; set; }
        public int fpzl { get; set; }
        public string fpdm { get; set; }
        public string fphm { get; set; }
        public string xsdjbh { get; set; }
        public decimal hjbhsje { get; set; }
        public decimal hjse { get; set; }
        public string kprq { get; set; }
        public int dybz { get; set; }  //打印标志1已打印 0未打印
        public int fpbszt { get; set; }//发票保送状态 0 未报送，1 已报送，2报送失败，3 报送中，4 验签失败
        public int zfbz { get; set; }
        public string infoxml { get; set; }

    }
}
