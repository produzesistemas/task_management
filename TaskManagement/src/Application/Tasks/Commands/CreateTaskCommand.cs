﻿
using Application.Common.Interfaces.ApiServices;
using Application.Tasks.Queries;
using AutoMapper;
using MediatR;

namespace Application.Tasks.Commands;
public class CreateTaskCommand : IRequest<TaskDto>
{
    public string Description { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public string ProjectId { get; set; } = string.Empty;
    public string Priority { get; set; } = string.Empty;
    public DateTime DueDate { get; set; }
}

public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, TaskDto>
{
    private readonly IMapper _mapper;
    private readonly ITaskApiService _TaskApiService;

    public CreateTaskCommandHandler(
            IMapper mapper,
        ITaskApiService taskApiService
    )
    {
        _mapper = mapper;
        _TaskApiService = taskApiService;
    }

    public async Task<TaskDto> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = new Domain.Entities.Task(
            request.Title,
            request.Description,
            request.Status,
            request.Priority,
            new Guid(request.UserId),
            new Guid(request.ProjectId),
            request.DueDate
            );
        return _mapper.Map<TaskDto>(await _TaskApiService.SaveTask(task));
    }

}



