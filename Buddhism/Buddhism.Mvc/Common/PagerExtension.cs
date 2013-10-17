using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buddhism.Mvc.Common;

namespace System.Collections.Generic
{
    public static class PagerExtension
    {
        public static PagedData<T> Page<T>(this IEnumerable<T> query, QueryInfo info) where T : class
        {
            return query.AsQueryable<T>().Page<T>(info);
        }

        public static PagedData<T> Page<T>(this IQueryable<T> query, QueryInfo info) where T : class
        {
            if (info.OrderBy.IsNotNullAndEmpty())
            {
                query = query.OrderBy<T>(info.OrderBy, info.IsDesc);
            }
            Pager pager = new Pager(info.Page, info.PageSize, query.Count<T>(), info.OrderBy, info.IsDesc);
            return new PagedData<T>(pager, query.Skip<T>(pager.SkipCount).Take<T>(pager.TakeCount).ToArray<T>());
        }

        //public static PagedData<T> Page<T>(this ICriteria criteria, ISession session, QueryInfo info) where T : class
        //{
        //    PreteatQueryInfo<T>(info);
        //    Pager pager = new Pager(info.Page, info.PageSize, 10, info.OrderBy, info.IsDesc);
        //    ICriteria criteria2 = (criteria.Clone() as ICriteria).SetFirstResult(pager.FristDataPos - 1).SetMaxResults(pager.TakeCount);
        //    criteria.ClearOrders();
        //    ICriteria criteria3 = criteria.SetProjection(new IProjection[] { Projections.RowCount() });
        //    IMultiCriteria criteria4 = session.CreateMultiCriteria().Add("list", criteria2).Add("totalCount", criteria3);
        //    int totalCount = (int)(criteria4.GetResult("totalCount") as IList)[0];
        //    pager = pager.SetTotalCount(totalCount);
        //    return new PagedData<T>(pager, (criteria4.GetResult("list") as IList).Cast<T>().ToList<T>());
        //}
    }
}

