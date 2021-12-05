
namespace read_feed.core.Entities
{
    public interface IUser : IScoped
    {
        string Email { get; set; }
    }
}