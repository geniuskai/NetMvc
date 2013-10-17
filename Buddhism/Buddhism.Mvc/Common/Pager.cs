using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buddhism.Mvc.Common
{
    public class Pager
    {
        private int _currentPage;
        private int _pageCount;
        private int _pageSize;
        private int _totalCount;

        public Pager(int currentPage, int pageSize, int totalCount, string orderBy, bool isDesc)
        {
            this.OrderBy = orderBy;
            this.IsDesc = isDesc;
            this.Init(currentPage, pageSize, totalCount);
        }
        private void Init(int currentPage, int pageSize, int totalCount)
        {
            this._pageSize = (pageSize > 1) ? pageSize : 1;
            if (totalCount > 0)
            {
                this._totalCount = totalCount;
                this._pageCount = (int)(((this._totalCount + this._pageSize) - 1L) / ((long)this._pageSize));
                if (this._pageCount == 0)
                {
                    this._pageCount = 1;
                }
                if (currentPage < 1)
                {
                    this._currentPage = 1;
                }
                else if (currentPage > this._pageCount)
                {
                    this._currentPage = this._pageCount;
                }
                else
                {
                    this._currentPage = currentPage;
                }
            }
            else
            {
                this._totalCount = this._pageCount = this._currentPage = 0;
            }
        }
        public Pager SetTotalCount(int totalCount)
        {
            return new Pager(this._currentPage, this._pageSize, totalCount, this.OrderBy, this.IsDesc);
        }
        public bool CanMoveNext
        {
            get{return ((this._pageCount > 0) && !this.IsLastPage);}
        }
        public bool CanMovePrev
        {
            get{return ((this._pageCount > 0) && !this.IsFirstPage);}
        }
        public bool CanMoveToFirstPage
        {
            get{return ((this._pageCount > 0) && !this.IsFirstPage);}
        }
        public bool CanMoveToLastPage
        {
            get{return ((this._pageCount > 0) && !this.IsLastPage);}
        }
        public int CurrentPage
        {
            get{return this._currentPage; }
        }

        public int FristDataPos
        {
            get{return (this.SkipCount + 1);}
        }

        public int FristPage
        {
            get{return 1;}
        }

        public bool IsDesc { get; private set; }

        public bool IsFirstPage
        {
            get{return ((this._pageCount > 0) && (this._currentPage == 1));}
        }

        public bool IsLastPage
        {
            get{return ((this._pageCount > 0) && (this._currentPage == this._pageCount));}
        }

        public int LastPage
        {
            get { return this._pageCount;}
        }

        public int NextPage
        {
            get{                              
              if (!this.IsLastPage) {
                    return (this._currentPage + 1);
                }
                return this._pageCount;
            }
        }

        public string OrderBy { get; private set; }

        public int PageCount
        {
            get{return this._pageCount;}
        }

        public int PageSize
        {
            get{return this._pageSize;}
        }

        public int PreviousPage
        {
            get
            {
                if (!this.IsFirstPage)
                {
                    return (this._currentPage - 1);
                }
                return 1;
            }
        }

        public int SkipCount
        {
            get{return (this._pageSize * (this._currentPage - 1));}
        }

        public int TakeCount
        {
            get
            {
                if (!this.IsLastPage)
                {
                    return this.PageSize;
                }
                int num = this.TotalCount % this.PageSize;
                if (num <= 0)
                {
                    return this.PageSize;
                }
                return num;
            }
        }

        public int TotalCount
        {
            get{return this._totalCount;}
        }
    }
}
