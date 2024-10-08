
namespace Domain.Entities;
public class Task
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Priority { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public Guid ProjectId { get; set; }
    public DateTime DueDate { get; set; }
    public User User { get; set; } = default!;
    public Project Project { get; set; } = default!;
}
