using read_feed.core.Entities;
using read_feed.core.Infra;

namespace read_feed.core.Clients;

/// <summary>
/// Client to update a provider data
/// </summary>
public interface IProviderClient
{
    /// <summary>
    /// Get the last inserted item
    /// </summary>
    /// <returns></returns>
    Task<Option<IReadItem>> GetLastAddedItem();

    /// <summary>
    /// Add items to current provider
    /// </summary>
    /// <param name="items"></param>
    /// <returns></returns>
    Task AddItems(IEnumerable<IReadItem> items);

    /// <summary>
    /// Remove items in list
    /// </summary>
    /// <param name="items"></param>
    /// <returns></returns>
    Task RemoveItems(IEnumerable<IReadItem> items);

    /// <summary>
    /// Remove items that contains url
    /// </summary>
    /// <param name="urls"></param>
    /// <returns></returns>
    Task RemoveItemsByUrl(IEnumerable<string> urls);

    /// <summary>
    /// Refresh current token and invalidate previous one
    /// </summary>
    Task<string> RefreshToken();
}
