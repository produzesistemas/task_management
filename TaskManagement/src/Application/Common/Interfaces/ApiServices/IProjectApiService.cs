using Domain.Entities;

namespace Application.Common.Interfaces.ApiServices;

public interface IProjectApiService
{
    public Task<Project> GetProject(Guid id);
    public Task<Project> SaveProject(Project project);
}
