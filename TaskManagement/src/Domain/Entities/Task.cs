
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

    public Task(string title, string description, string status, string priority, Guid userId, Guid projectId, DateTime dueDate)
    {
        this.Id = new Guid();
        this.Title = title;
        this.Description = description;
        this.Status = status;
        this.Priority = priority;
        this.UserId = userId;
        this.ProjectId = projectId;
        this.DueDate = dueDate;
    }

    public Task(Guid id, string title, string description, string status, Guid userId, DateTime dueDate)
    {
        this.Id = id;
        this.Title = title;
        this.Description = description;
        this.Status = status;
        this.UserId = userId;
        this.DueDate = dueDate;
    }

    public bool ChangeTitle(string title, string titleBase)
    {
        return title != titleBase ? true : false;
    }

    public bool ChangeStatus(string status, string statusBase)
    {
        return status != statusBase ? true : false;
    }

    public bool ChangeDueDate(DateTime DueDate, DateTime DueDateBase)
    {
        return DueDate != DueDateBase ? true : false;
    }

    public bool ChangeProject(Guid projectId, Guid projectIdBase)
    {
        return projectId != projectIdBase ? true : false;
    }

    public bool ChangeUser(Guid userId, Guid userIdBase)
    {
        return userId != userIdBase ? true : false;
    }

    public bool ChangeDescription(string description, string descriptionBase)
    {
        return description != descriptionBase ? true : false;
    }


}
