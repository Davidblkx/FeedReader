using read_feed.core.Entities;

namespace read_feed.core.ApiDto;

public class UserDto : IUser
{
    public string Email { get; set; } = string.Empty;
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Access { get; set; } = string.Empty;
}
