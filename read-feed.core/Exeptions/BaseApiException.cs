namespace read_feed.core.Exeptions;

public abstract class BaseApiException : Exception
{
    const string DEFAULT_MESSAGE = "Error in read_feed api";
    public int ErrorCode { get; set; }

    public BaseApiException(int errorCode, string? message = default)
        : base(message ?? DEFAULT_MESSAGE)
    { ErrorCode = errorCode; }

    public BaseApiException((int errorCode, string message) details)
        : base(details.message)
    { ErrorCode = details.errorCode; }
}