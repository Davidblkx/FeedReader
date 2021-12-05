using read_feed.core.Entities;

namespace read_feed.api.Entities;
public class ReadItem : IReadItem
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ProviderId { get; set; }
    public string Tags { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public DateTime Updated { get; set; }

    public virtual Provider Provider { get; set; } = null!;
}