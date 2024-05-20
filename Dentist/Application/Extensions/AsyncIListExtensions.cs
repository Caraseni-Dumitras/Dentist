using Core;

namespace Application.Extensions;

public static class AsyncIListExtensions
{
    public static async Task<IPagedList<T>> ToPagedListAsync<T>(this IList<T> source, int pageIndex, int pageSize, bool getOnlyTotalCount = false)
    {
        if (source == null)
            return new PagedList<T>(new List<T>(), pageIndex, pageSize);

        //min allowed page size is 1
        pageSize = Math.Max(pageSize, 1);

        var data = new List<T>();

        if (!getOnlyTotalCount)
            data.AddRange( source.Skip(pageIndex * pageSize).Take(pageSize).ToList());

        return new PagedList<T>(data, pageIndex, pageSize, source.Count);
    }
}