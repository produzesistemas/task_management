using Application.Common.Interfaces.ApiServices;
using AutoMapper;
using MediatR;

namespace Application.Projects.Queries.GetProjectById;

public class GetProjectByIdQuery : IRequest<ProjectDto>
{
    public Guid Id { get; set; }
}

public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectDto>
{
    private readonly IMapper _mapper;
    private readonly IProjectApiService _ProjectApiService;

    public GetProjectByIdQueryHandler
    (
        IMapper mapper,
                IProjectApiService projectApiService
    )
    {
        _mapper = mapper;
        _ProjectApiService = projectApiService;
    }

    public async Task<ProjectDto> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<ProjectDto>(await _ProjectApiService.GetProject(request.Id));
    }
}
