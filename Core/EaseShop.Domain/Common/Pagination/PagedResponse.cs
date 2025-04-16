namespace EaseShop.Domain.Common.Pagination;

public class PagedResponse<T>
{
    public List<T> Data { get; set; }
    public int TotalCount { get; set; }
    public int PageSize { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
}