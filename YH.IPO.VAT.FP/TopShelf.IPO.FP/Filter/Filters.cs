using System.Collections.Generic;
using System.Web.Http.Filters;

namespace TopShelf.IPO.FP.Filter
{
    public static class Filters
    {
        /// <summary>
        /// 
        /// </summary>
        private static List<IFilter> filters = new List<IFilter>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Filters"></param>
        internal static void UseFilters(this HttpFilterCollection Filters)
        {
            if (filters.Count > 0)
            {
                Filters.AddRange(filters);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        public static void Add(IFilter filter)
        {
            filters.Add(filter);
        }
    }
}
