
using Application.Common.Mappings;

namespace Application.Tasks.Queries;
public class TaskDto : IMapFrom<Domain.Entities.Task>
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Priority { get; set; } = string.Empty;
    public DateTime DueDate { get; set; }
    public Guid UserId { get; set; }
    public Guid ProjectId { get; set; }
}
