namespace read_feed.api.Services;

public static class ServiceExtensions
{
    public static void AddApiServices(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddTransient<InitializationService>();
        services.AddScoped<IAuthStatusService, AuthStatusService>();
    }
}
