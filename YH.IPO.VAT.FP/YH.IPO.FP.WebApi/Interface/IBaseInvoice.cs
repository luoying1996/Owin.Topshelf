

using YH.IPO.FP.WebApi.Enum;

namespace YH.IPO.FP.WebApi
{
    public interface IBaseInvoice
    {
        SIDEnum SID { get; }

        void DescType(string json);


    }
}
