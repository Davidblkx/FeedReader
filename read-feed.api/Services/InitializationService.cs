using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using read_feed.api.Data;
using read_feed.api.Entities;
using read_feed.core.Scopes;

namespace read_feed.api.Services;

public class InitializationService
{
    private readonly ReadFeedContext _context;
    private readonly ILogger<InitializationService> _logger;
    private readonly AppConfig _appConfig;

    public InitializationService(
        ILogger<InitializationService> logger, 
        ReadFeedContext context,
        IOptionsMonitor<AppConfig> config) 
    {
        _logger = logger;
        _context = context;
        _appConfig = config.CurrentValue;
    }

    public void Run()
    {
        _logger.LogInformation("Running ReadFeed Api initializaton...");

        RunMigrations();
        CreateUser();

        _logger.LogInformation("Running ReadFeed Api initializaton completed");
    }

    public void RunMigrations()
    {
        _logger.LogInformation("Running migrations...");
        _context.Database.Migrate();
        _logger.LogInformation("Running migrations completed");
    }

    public void CreateUser()
    {
        var hasUsers = _context.Users.Any(u => u.Email == _appConfig.AdminEmail);
        if (hasUsers)
        {
            _logger.LogInformation("User with email {email} already present", _appConfig.AdminEmail);
            return;
        }

        var user = _context.Users.Add(new User
        {
            Access = AccessScopes.Admin,
            Email = _appConfig.AdminEmail,
        });
        _context.SaveChanges();
        _logger.LogInformation("User created: {userId} [{email}]", user.Entity.Id, user.Entity.Email);

        _context.Tokens.Add(new Token
        {
            Access = AccessScopes.Admin,
            Expires = DateTime.UtcNow.AddYears(10),
            Name = "Default token",
            UserId = user.Entity.Id,
            Value = _appConfig.AdminToken
        });
        _context.SaveChanges();
        _logger.LogInformation("Token created for admin");
    }
}
