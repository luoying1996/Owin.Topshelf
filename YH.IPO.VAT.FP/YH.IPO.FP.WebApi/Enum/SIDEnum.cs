using System.ComponentModel;

namespace YH.IPO.FP.WebApi.Enum
{
    public enum SIDEnum
    {
        [Description("获取库存信息")]
        Inventory = 0,

        [Description("发票开具")]
        InvoiceOpening = 1,

        [Description("发票打印")]
        InvoicePrinting = 2,

        [Description("清单打印")]
        DetailedPrinting = 3,

        [Description("发票作废")]
        InvoiceInvalidation = 4,

        [Description("查询发票信息")]
        InvoiceInfo = 5,

        [Description("查询库存信息")]
        StockInfo = 6,

        [Description("下一发票机库存信息")]
        NextStockInfo = 7,

        [Description("启动开票服务")]
        StartInvoicingService = 12,

        [Description("关闭开票服务")]
        ClosingInvoicingService = 13,

        [Description("发票上传")]
        InvoiceUploading = 15,

        [Description("发票状态更新")]
        InvoiceStatusUpdate = 16,

        [Description("发票查询更新")]
        InvoiceQueryUpdate = 17,

        [Description("批量报送")]
        BatchDelivery = 20,

        [Description("机动车发票开具")]
        InvoiceForMotorVehicle = 22,

        [Description("机动车发票查询")]
        MotorVehicle = 24,

        [Description("金税设备查询")]
        GoldenTax = 25,
    }
}
