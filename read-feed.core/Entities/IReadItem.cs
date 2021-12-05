
namespace read_feed.core.Entities
{
    public interface IReadItem : IBaseEntity
    {
        string Description { get; set; }
        Guid ProviderId { get; set; }
        string Tags { get; set; }
        string Title { get; set; }
        DateTime Updated { get; set; }
        string Url { get; set; }
    }
}