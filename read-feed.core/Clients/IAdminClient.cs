using read_feed.core.Entities;
using read_feed.core.Infra;

namespace read_feed.core.Clients;

/// <summary>
/// Client for administration
/// </summary>
public interface IAdminClient
{
    /// <summary>
    /// Client to manage user tokens
    /// </summary>
    ITokenClient TokenClient { get; }

    /// <summary>
    /// Create a new user, email must be unique
    /// </summary>
    /// <param name="email"></param>
    /// <param name="access"></param>
    /// <returns></returns>
    Task<IUser> CreateUser(string email, string? access = default);

    /// <summary>
    /// Create a new provider
    /// </summary>
    /// <param name="name"></param>
    /// <param name="description"></param>
    /// <returns></returns>
    Task<IProvider> CreateProvider(string name, string? description = default);

    /// <summary>
    /// Finde user by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Option<IUser>> FindUser(Guid id);
    /// <summary>
    /// Find user user by email
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    Task<Option<IUser>> FindUser(string email);
    /// <summary>
    /// Get client for user id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<IUserClient> GetUserClient(Guid id);
    /// <summary>
    /// Get client for user email
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    Task<IUserClient> GetUserClient(string email);
    /// <summary>
    /// Get all users
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<IUser>> GetUsers();

    /// <summary>
    /// Find a provider by its id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Option<IProvider>> FindProvider(Guid id);
    /// <summary>
    /// Get client for a provider
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<IProviderClient> GetProviderClient(Guid id);
    /// <summary>
    /// Get all providers
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<IProvider>> GetProviders();
}
