
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
        var entity = new Domain.Entities.Task()
        {
            Id = Guid.NewGuid(),
            Description = task.Description, 
            Title = task.Title,
            Status = task.Status,
            ProjectId = task.ProjectId,
            UserId = task.UserId,
            Priority = task.Priority,
            DueDate = task.DueDate,
        };
        _context.Tasks.Add(entity);
        await _context.SaveChangesAsync();
        return await System.Threading.Tasks.Task.FromResult(entity);
    }

    public async Task<Domain.Entities.Task> UpdateTask(Domain.Entities.Task task)
    {
        
        var taskBase = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == task.Id);

        if (task.Status != taskBase!.Status)
        {
            var taskHistory = new TaskHistory();
            taskHistory.Description = string.Concat("Status alterado de ", taskBase.Status, " para ", task.Status);
            taskHistory.CreateDate = DateTime.Now;
            taskHistory.UserId = task.UserId;
            taskHistory.TaskId = taskBase.Id;
            _context.TaskHistorys.Add(taskHistory);
        }

        if (task.Title != taskBase.Title)
        {
            var taskHistory = new TaskHistory();
            taskHistory.Description = string.Concat("Título alterado de ", taskBase.Title, " para ", task.Title);
            taskHistory.CreateDate = DateTime.Now;
            taskHistory.UserId = task.UserId;
            taskHistory.TaskId = taskBase.Id;
            _context.TaskHistorys.Add(taskHistory);
        }

        if (task.Description != taskBase.Description)
        {
            var taskHistory = new TaskHistory();
            taskHistory.Description = string.Concat("Descrição da tarefa alterada de ", taskBase.Description, " para ", task.Description);
            taskHistory.CreateDate = DateTime.Now;
            taskHistory.UserId = task.UserId;
            taskHistory.TaskId = taskBase.Id;
            _context.TaskHistorys.Add(taskHistory);
        }

        if (task.DueDate != taskBase.DueDate)
        {
            var taskHistory = new TaskHistory();
            taskHistory.Description = string.Concat("Data da tarefa alterada de ", taskBase.DueDate, " para ", task.DueDate);
            taskHistory.CreateDate = DateTime.Now;
            taskHistory.UserId = task.UserId;
            taskHistory.TaskId = taskBase.Id;
            _context.TaskHistorys.Add(taskHistory);
        }

        if (task.ProjectId != taskBase.ProjectId)
        {
            var taskHistory = new TaskHistory();
            taskHistory.Description = string.Concat("Identificação do Projeto da tarefa alterada de ", taskBase.ProjectId, " para ", task.ProjectId);
            taskHistory.CreateDate = DateTime.Now;
            taskHistory.UserId = task.UserId;
            taskHistory.TaskId = taskBase.Id;
            _context.TaskHistorys.Add(taskHistory);
        }

        if (task.UserId != taskBase.UserId)
        {
            var taskHistory = new TaskHistory();
            taskHistory.Description = string.Concat("Identificação do usuário da tarefa alterada de ", taskBase.UserId, " para ", task.UserId);
            taskHistory.CreateDate = DateTime.Now;
            taskHistory.UserId = task.UserId;
            taskHistory.TaskId = taskBase.Id;
            _context.TaskHistorys.Add(taskHistory);
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
