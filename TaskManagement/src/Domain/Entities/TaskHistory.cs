
namespace Domain.Entities;
public class TaskHistory
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public Guid TaskId { get; set; }
    public DateTime CreateDate { get; set; }
    public User User { get; set; } = default!;
    public Task Task { get; set; } = default!;

    public TaskHistory(string description, Guid userId, Guid taskId)
    {
        this.Id = new Guid();
        this.Description = description;
        this.UserId = userId;
        this.TaskId = taskId;
        this.CreateDate = DateTime.Now;
    }
}
