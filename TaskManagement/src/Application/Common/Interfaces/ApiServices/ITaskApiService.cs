
namespace Application.Common.Interfaces.ApiServices
{
    public interface ITaskApiService
    {
        public Task<Domain.Entities.Task> SaveTask(Domain.Entities.Task task);
        public Task<Domain.Entities.Task> UpdateTask(Domain.Entities.Task task);
        public Task DeleteTask(Guid id);
    }
}
