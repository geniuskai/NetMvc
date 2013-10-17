using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buddhism.Mvc.Common
{
    public class PagedData<T> : IEnumerable<T>, IEnumerable
    {
        public PagedData(Pager pager, IEnumerable<T> data)
        {
            this.Pager = pager;
            this.Data = data;
        }
        public static PagedData<T> Empty(QueryInfo queryInfo)
        {
            return new PagedData<T>(new Pager(0, queryInfo.PageSize, 0, queryInfo.OrderBy, queryInfo.IsDesc), new T[0]);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return this.Data.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Data.GetEnumerator();
        }
        private IEnumerable<T> _Data;
        public IEnumerable<T> Data
        {
            get { return _Data; }
            set { _Data = value; }
        }
        private Pager _Pager;
        public Pager Pager
        {
            get { return _Pager; }
            set { _Pager = value; }
        }
    }
}
