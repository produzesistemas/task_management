﻿
using Application.Common.Interfaces.ApiServices;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.ApiServices;
public class ProjectApiService : IProjectApiService
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;

    public ProjectApiService(ApplicationDbContext context, ILogger<ApplicationDbContextInitialiser> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async System.Threading.Tasks.Task DeleteProject(Guid id)
    {
        var projectBase = await _context.Projects.FirstOrDefaultAsync(x => x.Id == id);
        await System.Threading.Tasks.Task.Run(() => _context.Projects.Remove(projectBase!));
        await _context.SaveChangesAsync();
    }

    public async Task<Project> GetProject(Guid id)
    {
        var entity = await _context.Projects.FirstOrDefaultAsync(x => x.Id.Equals(id));
        return entity!;
    }

    public async Task<Project> SaveProject(Project project)
    {
        _context.Projects.Add(project);
        await _context.SaveChangesAsync();
        return await System.Threading.Tasks.Task.FromResult(project);
    }
}
