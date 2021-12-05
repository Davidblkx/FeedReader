using read_feed.api.Data;
using read_feed.api.Entities;
using read_feed.core.Scopes;

namespace read_feed.api.Services
{
    public class AuthStatusService : IAuthStatusService
    {
        private readonly ILogger<AuthStatusService> _logger;
        private readonly ReadFeedContext _context;
        private readonly string _userToken;
        private readonly string _providerToken;

        private Token? _token;
        private Provider? _provider;

        public Token? Token
        {
            get
            {
                FetchUserToken();
                return _token;
            }
        }

        public Provider? Provider
        {
            get
            {
                FetchProvider();
                return _provider;
            }
        }

        public User? User => Token?.User;

        public AuthStatusService(ILogger<AuthStatusService> logger, ReadFeedContext context, IHttpContextAccessor httpContext)
        {
            _logger = logger;
            _context = context;
            _userToken = httpContext.HttpContext?
                .Request.Headers["x-token"].FirstOrDefault() ?? "";
            _providerToken = httpContext.HttpContext?
                .Request.Headers["x-provider"].FirstOrDefault() ?? "";
            _logger.LogInformation("Auth started token: {token}, provider: {provider}", _userToken, _providerToken);
        }

        public bool HasAllScopes(params string[] scopes)
            => Token?.HasAllScopes(scopes) ?? false;

        public bool HasAnyScopes(params string[] scopes)
            => Token?.HasAnyScope(scopes) ?? false;

        public bool HasProviderAccess(Guid providerId)
            => Provider?.Id == providerId || (Token?.HasAnyScope(providerId.ToString()) ?? false);

        private void FetchUserToken()
        {
            if (_token is not null) return;
            if (string.IsNullOrEmpty(_userToken)) return;

            _token = _context.Tokens.FirstOrDefault(e => e.Value == _userToken);
            if (_token is null) throw new InvalidOperationException("User token is invalid");
        }

        private void FetchProvider()
        {
            if (_provider is not null) return;
            if (string.IsNullOrEmpty(_providerToken)) return;

            _provider = _context.Providers.FirstOrDefault(e => e.Token == _providerToken);
            if (_provider is null) throw new InvalidOperationException("Provider token is invalid");
        }
    }
}
