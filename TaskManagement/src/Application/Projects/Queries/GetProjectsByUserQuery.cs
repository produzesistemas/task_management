using Application.Common.Interfaces.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Projects.Queries;
public class GetProjectsByUserQuery : IRequest<List<ProjectDto>>
{
    public Guid UserId { get; set; }
}

public class GetProjectsByUserQueryHandler : IRequestHandler<GetProjectsByUserQuery, List<ProjectDto>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _dbContext;

    public GetProjectsByUserQueryHandler(IMapper mapper, IApplicationDbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }

    public async Task<List<ProjectDto>> Handle(GetProjectsByUserQuery request, CancellationToken cancellationToken)
    {
        var results = _dbContext.Projects.Where(x => x.UserId == request.UserId).OrderByDescending(x => x.Name).ToList();
        return _mapper.Map<List<ProjectDto>>(results);
    }
}
