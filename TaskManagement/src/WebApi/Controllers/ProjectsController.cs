﻿using Application.Projects.Commands;
using Application.Projects.Queries;
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

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<ProjectDto>> CreateProject(CreateProjectCommand command)
    {
       return await Mediator.Send(command);
    }

    [HttpGet]
    public async Task<ActionResult<List<ProjectDto>>> GetProjectsByUser([FromQuery] GetProjectsByUserQuery query)
    {
        return await Mediator.Send(query);
    }
}
