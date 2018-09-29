using System.ComponentModel;

namespace YH.IPO.FP.WebApi.Enum
{
    /// <summary>
    /// 发票种类  获取每种发票的库存信息
    /// </summary>
    public enum InfoKindEnum
    {
        [Description("专用发票")]
        zhuanpiao = 0,
        [Description("普通发票")]
        pupiao = 2,
        [Description("货运发票")]
        huoyunpiao = 11,
        [Description("机动车票")]
        jidongpiao = 12,
        [Description("卷式发票")]
        juanshipiao = 41,
        [Description("电子发票")]
        dianzipiao = 51,
    }
    public enum CheckEWMEnum
    {
        [Description("开票")]
        kp = 0,
        [Description("校验")]
        yp = 1,
        [Description("空白作废")]
        kbzf = 2
    }

    public enum JdckindEnum
    {
        [Description("旧机动车")]
        jjdc = 1,
        [Description("新机动车")]
        xjdc = 2
    }
}
