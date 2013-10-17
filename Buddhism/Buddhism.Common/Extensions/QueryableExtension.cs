using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    public static class QueryableExtension
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> queryable, string property, bool desc)
        {
            return queryable.OrderBy<T>((property + (desc ? " desc" : "")), new object[0]);
        }

        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate, bool @if)
        {
            return (@if ? enumerable.Where<T>(predicate) : enumerable);
        }

        public static IQueryable<T> WhereIf<T>(this IQueryable<T> queryable, Expression<Func<T, bool>> predicate, bool @if)
        {
            return (@if ? queryable.Where<T>(predicate) : queryable);
        }
    }
}

