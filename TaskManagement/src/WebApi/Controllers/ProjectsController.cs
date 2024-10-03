using Application.Projects.Commands.CreateProject;
using Application.Projects.Queries.GetProjectById;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ApiControllerBase
{
    private readonly ILogger<ProjectsController> _logger;

    public ProjectsController(ILogger<ProjectsController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<ProjectDto>> GetProjectById([FromQuery] GetProjectByIdQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<ProjectDto>> CreateProject(CreateProjectCommand command)
    {
        try
        {
            return await Mediator.Send(command);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
