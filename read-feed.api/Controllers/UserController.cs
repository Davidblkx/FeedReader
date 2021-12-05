using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using read_feed.api.Data;
using read_feed.api.Services;
using read_feed.core.ApiDto;
using read_feed.core.Infra;

namespace read_feed.api.Controllers;

[ApiController]
[Route("v1/user")]
public class UserController : BaseController
{
    public UserController(
        ILogger<UserController> logger,
        ReadFeedContext context,
        IAuthStatusService auth,
        IMapper mapper
    ) : base(logger, context, auth, mapper) { }

    [HttpGet("{id}")]
    public Task<IActionResult> GetUser(Guid id)
        => RunAsync(async () =>
        {
            ValidateHasAccessToUser(id);
            var user = await _context.Users.FindAsync(id);
            if (user is null) return NotFound(ApiErrors.NotFound.ToResponse());
            return Ok(ApiResponse.Success(_mapper.Map<UserDto>(user)));
        });
}
