namespace read_feed.core.ApiDto;

public class ApiResponse<T>
{
    public T? Result { get; set; }
    public bool IsSuccess { get; set; }
    public int ErrorCode { get; set; }
    public string? Message { get; set; }
}

public static class ApiResponse
{
    public static ApiResponse<T> Success<T>(T result)
        => new() { Result = result, IsSuccess = true };
    public static ApiResponse<object> Error(int errorCode, string? error = default)
        => new() { Message = error, IsSuccess = false, ErrorCode = errorCode };
    public static ApiResponse<object> Error((int code, string message) err)
        => new() { Message = err.message, ErrorCode = err.code, IsSuccess = false };
}

public static class ApiResponseExtensions
{
    public static ApiResponse<object> ToResponse(this (int code, string msg) error) => ApiResponse.Error(error);
}