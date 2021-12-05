using read_feed.core.Entities;

namespace read_feed.api.Entities;
public class Token : IToken
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime Expires { get; set; } = DateTime.UtcNow.AddHours(1);
    public string Access { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public string Value { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;

    public virtual User User { get; set; } = null!;
}
