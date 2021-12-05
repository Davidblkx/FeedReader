using read_feed.core.Entities;

namespace read_feed.core.Scopes;

public static class Extensions
{
    public static List<string> GetScopes(this IScoped entity)
        => entity.Access?.Split(';').ToList() ?? new List<string>();

    public static bool HasAnyScope(this IScoped entity, params string[] scopes)
        => entity.GetScopes().Any(s => scopes.Contains(s));

    public static bool HasAllScopes(this IScoped entity, params string[] scopes)
    {
        var entityScopes = entity.GetScopes();
        return scopes.All(s => entityScopes.Contains(s));
    }

    public static T AddScopes<T>(this T entity, params string[] scopes) where T : IScoped
    {
        var entityScopes = entity.GetScopes();
        entityScopes.AddRange(scopes);
        entity.Access = string.Join(";", entityScopes.Distinct());
        return entity;
    }

    public static T RemoveScopes<T>(this T entity, params string[] scopes) where T : IScoped
    {
        var entityScopes = entity.GetScopes();
        entityScopes.RemoveAll(s => scopes.Contains(s));
        entity.Access = string.Join(";", entityScopes.Distinct());
        return entity;
    }
}