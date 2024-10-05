using Application.Common.Interfaces.Persistence;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Queries.GetUsers;
public class GetAllQuery : IRequest<List<UserDto>>
{
}

public class GetAllQueryHandler : IRequestHandler<GetAllQuery, List<UserDto>>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _dbContext;

    public GetAllQueryHandler(IMapper mapper, IApplicationDbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }

    public async Task<List<UserDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        var results = await _dbContext.Users.OrderByDescending(x => x.Name).ToListAsync();
        return _mapper.Map<List<UserDto>>(results);
    }
}
