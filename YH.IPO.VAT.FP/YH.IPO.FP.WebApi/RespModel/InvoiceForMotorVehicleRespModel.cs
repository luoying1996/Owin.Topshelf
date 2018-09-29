 

namespace YH.IPO.FP.WebApi.RespModel
{
    public class InvoiceForMotorVehicleRespModel : BaseRespModel
    {
        //public string retcode { get; set; }
        //public SIDEnum SID { get => SIDEnum.InvoiceForMotorVehicle; }
        //public string retmsg { get; set; }
        public decimal InfoAmount { get; set; }
        public decimal InfoTaxAmount { get; set; }
        public string InfoDate { get; set; }
        public string InfoTypeCode { get; set; }
        public string InfoNumber { get; set; }
        public string hisInfoTypeCode { get; set; }
        public string hisInfoNumber { get; set; }
        public string hisInfoKind { get; set; }
        public string machineryNo { get; set; }
        public string authorityPart { get; set; }
        public string authorityPartCode { get; set; }
        public string nsrsbh { get; set; }
        public int kpfwqh { get; set; }
        public int kpdh { get; set; }

    }
}
