using Application.Common.Interfaces.Persistence;
using building.data.Mappings;
using Domain.Entities;
using Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;
public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new UserMap().Configure(modelBuilder.Entity<User>());
        new ProjectMap().Configure(modelBuilder.Entity<Project>());
        new TaskMap().Configure(modelBuilder.Entity<Domain.Entities.Task>());
        new TaskHistoryMap().Configure(modelBuilder.Entity<TaskHistory>());
    }

    public DbSet<Project> Projects => Set<Project>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Domain.Entities.Task> Tasks => Set<Domain.Entities.Task>();
    public DbSet<TaskHistory> TaskHistorys => Set<TaskHistory>();
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}
