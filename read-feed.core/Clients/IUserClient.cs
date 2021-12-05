using read_feed.core.Entities;
using read_feed.core.Infra;

namespace read_feed.core.Clients;

/// <summary>
/// Client to handle users
/// </summary>
public interface IUserClient
{
    /// <summary>
    /// Update user email address
    /// </summary>
    /// <param name="newEmail"></param>
    /// <returns></returns>
    Task UpdateEmail(string newEmail);

    /// <summary>
    /// Get current user
    /// </summary>
    /// <returns></returns>
    Task<IUser> Get();

    /// <summary>
    /// Add a new access
    /// </summary>
    /// <param name="access"></param>
    /// <returns></returns>
    Task AddAccess(string access);

    /// <summary>
    /// Remove a access
    /// </summary>
    /// <param name="access"></param>
    /// <returns></returns>
    Task DeleteAccess(string access);

    /// <summary>
    /// Check if user has a access
    /// </summary>
    /// <param name="access"></param>
    /// <returns></returns>
    Task<bool> HasAccess(string access);

    /// <summary>
    /// Deactivate user
    /// </summary>
    /// <returns></returns>
    Task Deactivate();
}