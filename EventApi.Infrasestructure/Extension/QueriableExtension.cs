using System.Linq.Expressions;

namespace EventApi.Infrasestructure.Extension
{
    public static class QueriableExtension
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> predicate)
        {
            if (!condition)
            {
                return query;
            }

            return query.Where(predicate);
        }
        public static IQueryable<T> PaginateResult<T>(this IQueryable<T> query, int pageNumber, int pageSize)
        {
            pageNumber = pageNumber < 1 ? 1 : pageNumber;
            pageSize = pageSize < 1 ? 10 : pageSize;
            var skip = (pageNumber - 1) * pageSize;
            return query.Skip(skip).Take(pageSize);
        }
    }
}
