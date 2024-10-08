using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces.Persistence;
public interface IApplicationDbContext
{
    DbSet<Project> Projects { get; }
    DbSet<User> Users { get; }
    DbSet<Domain.Entities.Task> Tasks { get; }
    DbSet<TaskHistory> TaskHistorys { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
