namespace read_feed.core.Infra;

public static class ApiErrors
{
    public static (int code, string message) Generic => (501, "Unexpected error");
    public static (int code, string message) Forbidden => (403, "User has no access to resource");
    public static (int code, string message) NotFound => (404, "Can't find resource");
}
