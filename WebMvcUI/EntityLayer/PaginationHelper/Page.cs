namespace EntityLayer.PaginationHelper;

public class Page <T> where T : class
{
    public IEnumerable<T> Items { get; set; }
    public int TotalItemCount { get; set; }
    public int PageSize { get; set; }
}