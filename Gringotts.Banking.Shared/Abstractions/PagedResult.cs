namespace Gringotts.Banking.Shared.Abstractions;

public abstract class PagedResultBase
{
    public int CurrentPage { get; set; }
    public int TotalPageCount { get; set; }
    public int PageSize { get; set; }
    public int TotalItemCount { get; set; }

    public int FirstRowOnPage
    {

        get { return (CurrentPage - 1) * PageSize + 1; }
    }

    public int LastRowOnPage
    {
        get { return Math.Min(CurrentPage * PageSize, TotalItemCount); }
    }
}

public class PagedResult<T> : PagedResultBase where T : class
{
    public IList<T> Items { get; set; }

    public PagedResult()
    {
        Items = new List<T>();
    }
}