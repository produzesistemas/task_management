using Application.Tasks.Commands;
using Application.Tasks.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class TasksController : ApiControllerBase
{
    private readonly ILogger<TasksController> _logger;

    public TasksController(ILogger<TasksController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult<TaskDto>> SaveTask(CreateTaskCommand command)
    {

        return await Mediator.Send(command);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<TaskDto>> UpdateTask(UpdateTaskCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpGet]
    public async Task<ActionResult<List<TaskDto>>> GetAll([FromQuery] GetTasksByProjectQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] DeleteTaskCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    }
