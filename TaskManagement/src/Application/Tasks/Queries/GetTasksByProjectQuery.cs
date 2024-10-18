using Application.Common.Interfaces.Persistence;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Tasks.Queries;
public class GetTasksByProjectQuery : IRequest<List<TaskDto>>
{
    public Guid ProjectId { get; set; }
}

public class GetTasksByProjectQueryHandler : IRequestHandler<GetTasksByProjectQuery, List<TaskDto>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _dbContext;

    public GetTasksByProjectQueryHandler(IMapper mapper, IApplicationDbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }

    public async Task<List<TaskDto>> Handle(GetTasksByProjectQuery request, CancellationToken cancellationToken)
    {
        var results = await _dbContext.Tasks.Where(x => x.ProjectId == request.ProjectId).ToListAsync();
        return _mapper.Map<List<TaskDto>>(results);
    }
}
