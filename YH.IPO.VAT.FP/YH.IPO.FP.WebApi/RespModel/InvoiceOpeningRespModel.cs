 
namespace YH.IPO.FP.WebApi.RespModel
{
    public class InvoiceOpeningRespModel : BaseRespModel
    {
        //public string retcode { get; set; }
        //public SIDEnum SID { get => SIDEnum.InvoiceOpening; }
        //public string retmsg { get; set; }
        public string hisInfoKind { get; set; }
        public decimal InfoAmount { get; set; }
        public string InfoNumber { get; set; }
        public string InfoDate { get; set; }
        public string hisInfoNumber { get; set; }
        public decimal InfoTaxAmount { get; set; }
        public string hisInfoTypeCode { get; set; }
        public string InfoTypeCode { get; set; }
        public string nsrsbh { get; set; }
        public string kpfwqh { get; set; }
        public string kpdh { get; set; }
        public ListFlagEnum ListFlag { get; set; }
    }

    public enum ListFlagEnum
    {
        FQD = 0,
        QD = 1
    }
}
