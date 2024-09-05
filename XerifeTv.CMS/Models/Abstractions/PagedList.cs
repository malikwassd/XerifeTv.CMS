namespace XerifeTv.CMS.Models.Abstractions;

public sealed class PagedList<T>(
  int pageSize, 
  int currentPage,
  int totalPageCount, 
  IEnumerable<T> items) where T : class
{
  public int PageSize { get; private set; } = pageSize;
  public int CurrentPage { get; private set; } = currentPage;
  public int TotalPageCount { get; private set; } = totalPageCount;
  public IEnumerable<T> Items { get; private set; } = items;
  public bool HasPrevious => (CurrentPage > 1);
  public bool HasNext => (CurrentPage < TotalPageCount);
}
