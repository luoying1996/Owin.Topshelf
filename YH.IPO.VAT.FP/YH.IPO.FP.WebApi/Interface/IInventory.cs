using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml;
using YH.IPO.FP.WebApi.Enum;

/// <summary>
/// 该接口为 所有 项目的请求Model
/// </summary>
namespace YH.IPO.FP.WebApi
{
    #region 0 获取库存信息
    public class IInventory : IBaseInvoice
    {
        public SIDEnum SID => SIDEnum.Inventory;
        public InfoKindEnum InfoKind { get; set; }
        public void DescType(string json)
        {
            var model = JsonConvert.DeserializeObject<IInventory>(json);
            model.IsValid();
        }
    }
    #endregion

    #region 1  发票开具
    public class IInvoiceOpening : IBaseInvoice
    {
        public SIDEnum SID => SIDEnum.InvoiceOpening;
        [Required]
        public InfoKindEnum invoiceType { get; set; }
        [Required]
        public string customerName { get; set; }
        [Required]
        public string customerTaxNr { get; set; }
        public string customerAddressTel { get; set; }
        public string customerBankAccountNr { get; set; }
        public string sellerBankAccountNr { get; set; }
        public string sellerAddressTel { get; set; }
        public List<Invoiceitem> invoiceItems { get; set; }
        public string documentNr { get; set; }
        [Required]
        public string payee { get; set; }
        [Required]
        public string checker { get; set; }
        [Required]
        public bool listed { get; set; }
        [Required]
        public string issuer { get; set; }
        public string memo { get; set; }
        [Required]
        public CheckEWMEnum CheckEWM { get; set; }
        public void DescType(string json)
        {
            var model = JsonConvert.DeserializeObject<IInvoiceOpening>(json);
            model.IsValid();
        }
    }
    public class Invoiceitem
    {
        [Required]
        public decimal value { get; set; }
        [Required]
        public string productName { get; set; }
        public string productUnit { get; set; }
        public string productSpec { get; set; }
        [Required]
        public bool includeTax { get; set; }
        public string TaxDeduction { get; set; }
        [Required]
        public decimal tax { get; set; }
        public int quantity { get; set; }
        [Required]
        public string GoodsTaxNo { get; set; }
        public string ZeroTax { get; set; }
        [Required]
        public string GoodsNoVer { get; set; }
        [Required]
        public string TaxPre { get; set; }
        [Required]
        public decimal taxRate { get; set; }
        public string CropGoodsNo { get; set; }
        public decimal price { get; set; }
        public string TaxPreCon { get; set; }
    }
    #endregion

    #region 2. 发票打印

    public class InvoicePrinting : IBaseInvoice
    {
        public SIDEnum SID => SIDEnum.InvoicePrinting;
        [Required]
        public InfoKindEnum InfoKind { get; set; }
        [Required]
        public string InfoNumber { get; set; }
        [Required]
        public string InfoTypeCode { get; set; }
        public InfoKindEnum? PrintKind { get; set; }

        public void DescType(string json)
        {
            var model = JsonConvert.DeserializeObject<InvoicePrinting>(json);
            model.IsValid();
        }
    }

    #endregion

    #region 3. 清单打印
    public class DetailedPrinting : IBaseInvoice
    {
        public SIDEnum SID => SIDEnum.DetailedPrinting;
        public InfoKindEnum InfoKind { get; set; }
        [Required]
        public string InfoNumber { get; set; }
        [Required]
        public string InfoTypeCode { get; set; }
        public void DescType(string json)
        {
            var model = JsonConvert.DeserializeObject<DetailedPrinting>(json);
            model.IsValid();
        }
    }
    #endregion

    #region 4. 发票作废  返回 SID
    public class InvoiceInvalidation : IBaseInvoice
    {
        public SIDEnum SID => SIDEnum.InvoiceInvalidation;

        public InfoKindEnum InfoKind { get; set; }
        [Required]
        public string InfoNumber { get; set; }
        [Required]
        public string InfoTypeCode { get; set; }
        public string issuer { get; set; }
        public void DescType(string json)
        {
            var model = JsonConvert.DeserializeObject<InvoiceInvalidation>(json);
            model.IsValid();
        }
    }
    #endregion

    #region 5. 查询发票信息  返回的还没定义
    public class InvoiceInfo : IBaseInvoice
    {
        public SIDEnum SID => SIDEnum.InvoiceInfo;
        public string xsdh { get; set; }
        public InfoKindEnum fpzl { get; set; }
        [Required]
        public string gfmc { get; set; }
        [Required]
        public string gfsh { get; set; }
        [Required]
        public string kpjh { get; set; }
        [Required]
        public string xfmc { get; set; }
        [Required]
        public string xfsh { get; set; }
        [Required]
        public string fpdm { get; set; }
        [Required]
        public string fphm { get; set; }
        public string kpdh { get; set; }
        [Required]
        public string zfbz { get; set; }
        [Required]
        public string qdbz { get; set; }
        public string dybz { get; set; }
        public string bsbz { get; set; }
        public string RecNo { get; set; }
        public string BeginDate { get; set; }
        public string EndDate { get; set; }
        public string PageSize { get; set; }
        public string PageIndex { get; set; }
        public void DescType(string json)
        {
            var model = JsonConvert.DeserializeObject<InvoiceInfo>(json);
            model.IsValid();
        }
    }
    #endregion

    #region 6. 查询库存信息 返: StockInfoRespModel
    public class StockInfo : IBaseInvoice
    {
        public SIDEnum SID => SIDEnum.StockInfo;
        public void DescType(string json)
        {
            var model = JsonConvert.DeserializeObject<StockInfo>(json);
            model.IsValid();
        }
    }
    #endregion

    #region 7. 查询下一发票机库存信息  返回的还没定义
    public class NextStockInfo : IBaseInvoice
    {
        public SIDEnum SID => SIDEnum.NextStockInfo;
        public void DescType(string json)
        {
            var model = JsonConvert.DeserializeObject<NextStockInfo>(json);
            model.IsValid();
        }
    }
    #endregion

    #region 12. 启动开票服务  返回 PtVer:interager
    public class StartInvoicingService : IBaseInvoice
    {
        public SIDEnum SID => SIDEnum.StartInvoicingService;
        public void DescType(string json)
        {
            var model = JsonConvert.DeserializeObject<StartInvoicingService>(json);
            model.IsValid();
        }
    }
    #endregion

    #region 13. 关闭开票服务  返:空
    public class ClosingInvoicingService : IBaseInvoice
    {
        public SIDEnum SID => SIDEnum.ClosingInvoicingService;
        public void DescType(string json)
        {
            var model = JsonConvert.DeserializeObject<ClosingInvoicingService>(json);
            model.IsValid();
        }
    }
    #endregion

    #region 15. 发票上传 返:空  根据发票代码、号码，上传指定发票（建议采用自动上传，如果控制台设置了上传则SID=15和SID=16的接口可以忽略）
    public class InvoiceUploading : IBaseInvoice
    {
        public SIDEnum SID => SIDEnum.InvoiceUploading;

        [Required, MaxLength(20)]
        public string fpdm { get; set; }
        [Required, MaxLength(20)]
        public string fphm { get; set; }
        public void DescType(string json)
        {
            var model = JsonConvert.DeserializeObject<InvoiceUploading>(json);
            model.IsValid();
        }
    }
    #endregion

    #region 16. 发票状态更新 返:info:string  更新已成功上传到局端的发票本地状态信息（建议采用自动上传，如果控制台设置了上传则SID=15和SID=16的接口可以忽略）
    public class InvoiceStatusUpdate : IBaseInvoice
    {
        public SIDEnum SID => SIDEnum.InvoiceStatusUpdate;

        [Required, MaxLength(20)]
        public string fpdm { get; set; }
        [Required, MaxLength(20)]
        public string fphm { get; set; }
        public void DescType(string json)
        {
            var model = JsonConvert.DeserializeObject<InvoiceStatusUpdate>(json);
            model.IsValid();
        }
    }
    #endregion

    #region 17. 单张发票查询  InvoiceQueryUpdateRespModel
    public class InvoiceQueryUpdate : IBaseInvoice
    {
        public SIDEnum SID => SIDEnum.InvoiceQueryUpdate;

        //注意：xsdbh与fpzl、fpdm、fphm是互斥条件，传销售单号就不按照fpzl,fpdm,fphm来查询
        public string xsdbh { get; set; }
        public InfoKindEnum fpzl { get; set; }
        [Required, MaxLength(20)]
        public string fpdm { get; set; }
        [Required, MaxLength(20)]
        public string fphm { get; set; }
        public void DescType(string json)
        {
            var model = JsonConvert.DeserializeObject<InvoiceQueryUpdate>(json);
            model.IsValid();
        }
    }
    #endregion

    #region 20. 批处理接口  批处理接口可实现多功能，以下主要对红字发票的发票做说明
    public class BatchDelivery : IBaseInvoice
    {
        public SIDEnum SID => SIDEnum.BatchDelivery;

        // 以下结构数据经过base64后，直接放入SIDPARAM即可。
        //{"param":"信息结构内容"}
        //14.1.2 信息结构内容
        //<?xml version="1.0" encoding="GBK"?>
        //<FPXT_COM_INPUT><ID></ID><DATA></DATA></FPXT_COM_INPUT>

        //注：功能请求的内容置于DATA 节点内，且此节点内的内容经过Base64 GB2312编码。以下红字专用发票信息表上传内容及红字专用发票信息表下载内容，匀经过 Base64编码后，置于此节点中。
        public string param { get; set; }

        public void DescType(string xml)
        {
            //XmlDocument doc = new XmlDocument();
            //doc.LoadXml(xml);
            //XmlNode xn = doc.SelectSingleNode("FPXT_COM_INPUT");
            //var fp = doc.SelectNodes("FPXT_COM_INPUT");

            //foreach (XmlElement item in xn.ChildNodes)
            //{
            //    var inn_text = item["DATA"].InnerText;
            //}

        }
    }
    #endregion

    #region 22 机动车发票开具  根据填开信息，完成机动车发票开具。
    public class InvoiceForMotorVehicle : IBaseInvoice
    {
        public SIDEnum SID => SIDEnum.InvoiceForMotorVehicle;

        public string sellerTaxNr { get; set; }
        public int kpdh { get; set; }
        public int kpfwqh { get; set; }
        [Required, MaxLength(100)]
        public string documentNr { get; set; }
        public CheckEWMEnum CheckEWM { get; set; }
        [Required, MaxLength(2)]
        public InfoKindEnum infoKind { get; set; }
        public JdckindEnum Jdckind { get; set; }
        [Required, MaxLength(72)]
        public string infoClientName { get; set; }
        public string infoClientTaxCode { get; set; }
        [Required, MaxLength(22)]
        public string idCard { get; set; }
        [Required, MaxLength(40)]
        public string vehicleKind { get; set; }
        [Required, MaxLength(60)]
        public string brandModel { get; set; }
        [Required, MaxLength(32)]
        public string originPlace { get; set; }
        public string qualityCertificate { get; set; }
        public string impCertificateNo { get; set; }
        public string commInspectionNo { get; set; }
        public string enginNo { get; set; }
        [Required, MaxLength(23)]
        public string vehicleNo { get; set; }
        public string manufacturerName { get; set; }
        [Required, MaxLength(8)]
        public string infoInvoicer { get; set; }
        public decimal amountTaxTotal { get; set; }
        public string sellerPhone { get; set; }
        public string sellerAccount { get; set; }
        public string sellerAddress { get; set; }
        public string sellerBank { get; set; }
        public decimal infoTaxRate { get; set; }
        public string tonnage { get; set; }
        public string peopleNo { get; set; }
        public string infoNotes { get; set; }
        public string GoodsNoVer { get; set; }
        public string GoodsTaxNo { get; set; }
        public string TaxPre { get; set; }
        public string TaxPreCon { get; set; }
        public string ZeroTax { get; set; }
        public string CropGoodsNo { get; set; }
        public string TaxDeduction { get; set; }
        public void DescType(string json)
        {
            var model = JsonConvert.DeserializeObject<InvoiceForMotorVehicle>(json);
            model.IsValid();
        }
    }
    #endregion

    #region 24 机动车发票查询
    public class MotorVehicle : IBaseInvoice
    {
        public SIDEnum SID => SIDEnum.MotorVehicle;
        public string xsdh { get; set; }
        [Required, MaxLength(100)]
        public string gfmc { get; set; }
        public string gfsh { get; set; }
        [Required, MaxLength(100)]
        public string xfmc { get; set; }
        [Required, MaxLength(20)]
        public string xfsh { get; set; }
        [Required, MaxLength(100)]
        public string fpdm { get; set; }
        [Required, MaxLength(10)]
        public string fphm { get; set; }
        [Required, MaxLength(8)]
        public string kpjh { get; set; }
        [Required, MaxLength(1)]
        public string zfbz { get; set; }
        public string qdbz { get; set; }
        [Required]
        public string dybz { get; set; }
        public string bsbz { get; set; }
        public string BeginDate { get; set; }//yyyy-MM-dd
        public string EndDate { get; set; }//yyyy-MM-dd
        public string PageSize { get; set; }
        public string PageIndex { get; set; }


        public InfoKindEnum fpzl { get; set; }

        public void DescType(string json)
        {
            var model = JsonConvert.DeserializeObject<MotorVehicle>(json);
            model.IsValid();
        }
    }

    #endregion

    #region  25 金税设备查询
    public class GoldenTax : IBaseInvoice
    {
        public SIDEnum SID => SIDEnum.GoldenTax;

        public string paran { get; set; }
        public void DescType(string json)
        {
            var model = JsonConvert.DeserializeObject<GoldenTax>(json);
            model.IsValid();
        }
    }
    #endregion
}
