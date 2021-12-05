
namespace read_feed.core.Entities
{
    public interface IProvider : IBaseEntity
    {
        string Description { get; set; }
        string Name { get; set; }
        string Token { get; set; }
    }
}