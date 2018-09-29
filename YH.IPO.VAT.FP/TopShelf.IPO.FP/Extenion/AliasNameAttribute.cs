using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopShelf.IPO.FP.Extenion
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public class AliasNameAttribute : Attribute
    {
        /// <summary>
        /// 接口/Action别名
        /// </summary>
        /// <param name="alias">接口/Action别名</param>
        public AliasNameAttribute(string alias)
        {
            if (string.IsNullOrWhiteSpace(alias))
            {
                throw new ArgumentException("接口别名不能为空");
            }
            Alias = alias;
        }
        /// <summary>
        /// 接口/Action别名
        /// </summary>
        public string Alias { get; set; } = null;
    }
}
