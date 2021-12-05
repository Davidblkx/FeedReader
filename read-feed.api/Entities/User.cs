using read_feed.core.Entities;
using System.Collections.ObjectModel;

namespace read_feed.api.Entities;

public class User : IUser
{
    public string Email { get; set; } = string.Empty;
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Access { get; set; } = string.Empty;

    public virtual Collection<Token> Tokens { get; set; } = null!;
}