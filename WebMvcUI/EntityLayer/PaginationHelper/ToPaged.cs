using System.Collections;
using System.Linq.Expressions;

namespace EntityLayer.PaginationHelper;

public static class ToPagedList
{
    public static Page<T> ToPaged<T>(this IQueryable<T> src, int pageIndex, int pageSize)
        where T : class
    {

        var results = new Page<T>
        {
            TotalItemCount = src.Count(),
            PageSize = pageSize,
            Items = src.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList()
        };

        return results;
    }

}