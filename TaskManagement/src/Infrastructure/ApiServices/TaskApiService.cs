
using System.Text;
using Application.Common.Interfaces.ApiServices;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.ApiServices;
public class TaskApiService : ITaskApiService
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;


    public TaskApiService(ApplicationDbContext context, ILogger<ApplicationDbContextInitialiser> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Domain.Entities.Task> SaveTask(Domain.Entities.Task task)
    {
        var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == task.ProjectId);
        var tasks = _context.Tasks.Where(p => p.ProjectId == project!.Id).ToListAsync().Result.Count();
        project!.ValidateQuantityTask(tasks);

        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return await System.Threading.Tasks.Task.FromResult(task);
    }

    public async Task<Domain.Entities.Task> UpdateTask(Domain.Entities.Task task)
    {
        var taskBase = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == task.Id);
        if (taskBase!.ChangeTitle(task.Title, taskBase.Title))
        {
            var history = new TaskHistory(string.Concat("Título alterado de ", taskBase.Title, " para ", task.Title), task.UserId, taskBase.Id);
            _context.TaskHistorys.Add(history);
        }

        if (taskBase!.ChangeStatus(task.Status, taskBase!.Status))
        {
            var history = new TaskHistory(string.Concat("Status alterado de ", taskBase.Status, " para ", task.Status), task.UserId, taskBase.Id);
            _context.TaskHistorys.Add(history);
        }

        if (taskBase!.ChangeDescription(task.Description, taskBase.Description))
        {
            var history = new TaskHistory(string.Concat("Descrição da tarefa alterada de ", taskBase.Description, " para ", task.Description), task.UserId, taskBase.Id);
            _context.TaskHistorys.Add(history);
        }

        if (taskBase!.ChangeDueDate(task.DueDate, taskBase.DueDate))
        {
            var history = new TaskHistory(string.Concat("Data da tarefa alterada de ", taskBase.DueDate, " para ", task.DueDate), task.UserId, taskBase.Id);
            _context.TaskHistorys.Add(history);
        }

        if (taskBase!.ChangeProject(task.ProjectId, taskBase.ProjectId))
        {
            var history = new TaskHistory(string.Concat("Identificação do Projeto da tarefa alterada de ", taskBase.ProjectId, " para ", task.ProjectId), task.UserId, taskBase.Id);
            _context.TaskHistorys.Add(history);
        }

        if (taskBase!.ChangeUser(task.UserId, taskBase.UserId))
        {
            var history = new TaskHistory(string.Concat("Identificação do usuário da tarefa alterada de ", taskBase.UserId, " para ", task.UserId), task.UserId, taskBase.Id);
            _context.TaskHistorys.Add(history);
        }

        taskBase!.Status = task.Status;
        taskBase.Title = task.Title;
        taskBase.Description = task.Description;
        taskBase.ProjectId = task.ProjectId;
        taskBase.UserId = task.UserId;
        taskBase.DueDate = task.DueDate;

        _context.Update(taskBase);
        await _context.SaveChangesAsync();
        return await System.Threading.Tasks.Task.FromResult(taskBase);
    }

    public async System.Threading.Tasks.Task DeleteTask(Guid id)
    {
        var taskBase = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        await System.Threading.Tasks.Task.Run(() => _context.Tasks.Remove(taskBase!));
        await _context.SaveChangesAsync();
    }
}
