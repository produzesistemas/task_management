using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Projects.Queries;

public class ProjectDto : IMapFrom<Project>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid UserId { get; set; }
}
