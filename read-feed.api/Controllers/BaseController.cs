using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using read_feed.api.Data;
using read_feed.api.Services;
using read_feed.core.ApiDto;
using read_feed.core.Exeptions;
using read_feed.core.Infra;
using read_feed.core.Scopes;

namespace read_feed.api.Controllers;

public abstract class BaseController : ControllerBase
{
    protected readonly ILogger _logger;
    protected readonly ReadFeedContext _context;
    protected readonly IAuthStatusService _auth;
    protected readonly IMapper _mapper;

    public BaseController(
        ILogger logger,
        ReadFeedContext context,
        IAuthStatusService auth,
        IMapper mapper)
    {
        _logger = logger;
        _context = context;
        _auth = auth;
        _mapper = mapper;
    }

    protected async Task<IActionResult> RunAsync(Func<Task<IActionResult>> action)
    {
        try
        {
            return await action();
        }
        catch (BaseApiException apiEx)
        {
            _logger.LogError(apiEx, "Api Error {code}: {message}", apiEx.ErrorCode, apiEx.Message);
            var result = ApiResponse.Error(apiEx.ErrorCode, apiEx.Message);
            return apiEx switch
            {
                ForbiddenException ex => StatusCode(401, result),
                _ => StatusCode(501, result)
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Api Error {code}: {message}", ApiErrors.Generic.code, ex.Message);
            var result = ApiResponse.Error(ApiErrors.Generic.code, ApiErrors.Generic.message);
            return StatusCode(501, result);
        }
    }

    protected void ValidateHasAccessToUser(Guid id)
    {
        if (_auth.HasAnyScopes(AccessScopes.Admin)) return;
        if (_auth.User?.Id == id) return;

        throw new ForbiddenException();
    }
}
