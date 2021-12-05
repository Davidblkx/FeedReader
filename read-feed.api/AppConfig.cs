namespace read_feed.api;

public class AppConfig
{
    /// <summary>
    /// Email to use for default admin
    /// </summary>
    public string AdminEmail { get; set; } = string.Empty;

    /// <summary>
    /// Initial token to authenticate
    /// </summary>
    public string AdminToken { get; set; } = String.Empty;
}