 

namespace YH.IPO.FP.WebApi.RespModel
{
    public class InventoryRespModel : BaseRespModel
    {
        //public string retcode { get; set; }
        //public SIDEnum SID { get => SIDEnum.Inventory; }
        //public string retmsg { get; set; }
        public int InvMcType { get; set; }
        public string MachineNo { get; set; }
        public string CorpName { get; set; }
        public string Kpfwqh { get; set; }
        public string CheckCode { get; set; }
        public int IsRepReached { get; set; }
        public int IsLockReached { get; set; }
        public int InvStock { get; set; }
        public string InfoNumber { get; set; }
        public int UploadMode { get; set; }
        public string TaxCode { get; set; }
        public string TaxClock { get; set; }
        public string InfoTypeCode { get; set; }
    }
}
