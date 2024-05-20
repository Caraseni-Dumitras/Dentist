namespace Core;

public class PagedListFilters
{
    public int PageIndex { get; set; } = 0;
    public int PageSize { get; set; } = int.MaxValue;
}