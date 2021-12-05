using read_feed.api.Entities;

namespace read_feed.api.Services
{
    public interface IAuthStatusService
    {
        /// <summary>
        /// Current provider
        /// </summary>
        Provider? Provider { get; }
        /// <summary>
        /// Current token
        /// </summary>
        Token? Token { get; }
        /// <summary>
        /// Current user
        /// </summary>
        User? User { get; }

        /// <summary>
        /// Check if all scopes are present in token
        /// </summary>
        /// <param name="scopes"></param>
        /// <returns></returns>
        bool HasAllScopes(params string[] scopes);
        /// <summary>
        /// Check if at least one scope is present in token
        /// </summary>
        /// <param name="scopes"></param>
        /// <returns></returns>
        bool HasAnyScopes(params string[] scopes);
        /// <summary>
        /// Check has access to provider
        /// </summary>
        /// <param name="providerId"></param>
        /// <returns></returns>
        bool HasProviderAccess(Guid providerId);
    }
}