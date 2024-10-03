using Application.Common.Mappings;

namespace Application.Projects.Queries.GetProjectById;

public class ProjectDto : IMapFrom<Domain.Entities.Project>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
