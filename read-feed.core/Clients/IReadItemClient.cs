using read_feed.core.Entities;
using read_feed.core.Infra;

namespace read_feed.core.Clients;

/// <summary>
/// Client to interact with <see cref="ReadItem"/> api
/// </summary>
public interface IReadItemClient
{
    /// <summary>
    /// Try to get the item for an Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Option<IReadItem>> GetById(Guid id);

    /// <summary>
    /// Return all items for a provider
    /// </summary>
    /// <param name="provider"></param>
    /// <returns></returns>
    Task<PageResponse<IReadItem>> GetItemsForProvider(Guid providerId, int skip = 0, int total = 100);

    /// <summary>
    /// Return items for a provider, added since a url
    /// </summary>
    /// <param name="provider"></param>
    /// <param name="lastUrl"></param>
    /// <returns></returns>
    Task<PageResponse<IReadItem>> GetItemsForProvider(Guid providerId, string lastUrl, int skip = 0, int total = 100);
}
