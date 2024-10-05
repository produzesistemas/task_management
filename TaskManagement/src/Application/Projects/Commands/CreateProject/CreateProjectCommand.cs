
using Application.Common.Interfaces.ApiServices;
using Application.Projects.Queries.GetProjectById;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Projects.Commands.CreateProject;
public class CreateProjectCommand : IRequest<ProjectDto>
{
    public string Name { get; set; } = string.Empty;
    public Guid UserId { get; set; }
}

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, ProjectDto>
{
    private readonly IMapper _mapper;
    private readonly IProjectApiService _ProjectApiService;

    public CreateProjectCommandHandler
    (
        IMapper mapper,
        IProjectApiService projectApiService
    )
    {
        _mapper = mapper;
        _ProjectApiService = projectApiService;
    }

    public async Task<ProjectDto> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = new Project
        {
            Name = request.Name,
            UserId = request.UserId,
        };
        return _mapper.Map<ProjectDto>(await _ProjectApiService.SaveProject(project));
    }
}
