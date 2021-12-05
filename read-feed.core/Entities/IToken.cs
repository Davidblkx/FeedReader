
namespace read_feed.core.Entities
{
    public interface IToken : IScoped
    {
        DateTime Expires { get; set; }
        Guid UserId { get; set; }
        string Value { get; set; }
        string Name { get; set; }
    }
}