using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buddhism.Mvc.Common
{
    public class QueryInfo
    {
        public string OrderBy { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public bool IsDesc { get; set; }

        public bool NeedSort
        {
            get{return !string.IsNullOrEmpty(this.OrderBy);}
        }
        public QueryInfo()
        {
            this.Page = 1;
            this.PageSize = 10;
            this.OrderBy = "";
            this.IsDesc = false;
        }
    }
}
