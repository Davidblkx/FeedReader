namespace read_feed.core.Scopes;

public static class AccessScopes
{
    /// <summary>
    /// Can do anything
    /// </summary>
    public static readonly string Admin = nameof(Admin);

    /// <summary>
    /// Can read information
    /// </summary>
    public static readonly string Read = nameof(Read);

    /// <summary>
    /// Can create new tokens
    /// </summary>
    public static readonly string CreateToken = nameof(CreateToken);
}
