namespace Domain.Entities;
public class Project
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid UserId { get; set; }
    public User User { get; set; } = default!;

    public Project(string name, Guid userId)
    {
        this.Id = Guid.NewGuid();
        this.Name = name;
        this.UserId = userId;
    }
}
