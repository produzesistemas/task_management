
using Application.Common.Exceptions;
using System.Net;
using Application.Common.Interfaces.ApiServices;
using Azure;
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
    public async Task<Project> GetProject(Guid id)
    {
        var entity = await _context.Projects.FirstOrDefaultAsync(x => x.Id.Equals(id));
        return entity!;
    }

    public async Task<Project> SaveProject(Project project)
    {
            var entity = new Project()
        {
            Id = Guid.NewGuid(),
            Name = project.Name,
        };
        _context.Projects.Add(entity);
        await _context.SaveChangesAsync();
        return await Task.FromResult(entity);
    }
}
