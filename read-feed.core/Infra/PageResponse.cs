namespace read_feed.core.Infra;

public class PageResponse<T>
{
    public IEnumerable<T> Result { get; }
    public int Total { get; }
    public int Skip { get; }

    public PageResponse(int skip, int total, IEnumerable<T> items)
    {
        Total = total;
        Skip = skip;
        Result = items;
    }

    public PageResponse(int skip, List<T> items)
    {
        Total = items.Count;
        Skip = skip;
        Result = items;
    }
}
