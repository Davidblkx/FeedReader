using read_feed.core.Entities;
using read_feed.core.Infra;

namespace read_feed.core.Clients;

/// <summary>
/// Client to handle user tokens
/// </summary>
public interface ITokenClient
{
    /// <summary>
    /// Create a new token
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="permissions"></param>
    /// <param name="duration"></param>
    /// <returns></returns>
    Task RequestToken(Guid userId, string permissions, TimeSpan? duration = default);

    /// <summary>
    /// Invalidate a token
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    Task InvalidateToken(string token);

    /// <summary>
    /// Check if token exists and return it
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    Task<Option<IToken>> CheckToken(string token);
}