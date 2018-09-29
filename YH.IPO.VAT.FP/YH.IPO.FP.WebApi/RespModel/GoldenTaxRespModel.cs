 

namespace YH.IPO.FP.WebApi.RespModel
{
    class GoldenTaxRespModel : BaseRespModel
    {
        //public string retcode { get; set; }
        //public SIDEnum SID { get => SIDEnum.GoldenTax; }
        //public string retmsg { get; set; }
        public string responseMsg { get; set; }
        public string kpfwqh { get; set; }
        public int MachineNo { get; set; }
        public string CorpName { get; set; }
        public string TaxCode { get; set; }
        public string CheckCode { get; set; }
        public int InvMcType { get; set; }//0打开的是防伪开票；1打开的是开票服务器
    }
}
