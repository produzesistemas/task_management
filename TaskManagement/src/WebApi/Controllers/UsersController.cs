using Application.BlogPreviews.Queries.GetBlogPreviews;
using Application.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ApiControllerBase
{
    private readonly ILogger<UsersController> _logger;

    public UsersController(ILogger<UsersController> logger)
    {
        _logger = logger;
    }

    //[HttpGet]
    //public async Task<ActionResult<UserDto>> GetUserById([FromQuery] GetUserByIdQuery query)
    //{
    //    return await Mediator.Send(query);
    //}

    [HttpGet]
    public async Task<ActionResult<List<UserDto>>> GetAll([FromQuery] GetAllQuery query)
    {
        return await Mediator.Send(query);
    }
}
