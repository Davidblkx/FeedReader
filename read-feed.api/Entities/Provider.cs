using read_feed.core.Entities;
using System.Collections.ObjectModel;

namespace read_feed.api.Entities;

public class Provider : IProvider
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;

    public virtual Collection<ReadItem> ReadItems { get; set; } = null!;
}