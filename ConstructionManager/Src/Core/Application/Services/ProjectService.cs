using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Domain.Projects;

namespace Application.Services;

public class ProjectService
{
    private readonly IProjectRepository _projectRepository;

    public ProjectService(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<IEnumerable<Project>> GetAllAsync()
    {
        return await _projectRepository.GetAllAsync();
    }

    public async Task<IEnumerable<Project>> GetAllProjectsAsync()
    {
        return await _projectRepository.GetAllAsync();
    }

    public async Task<Project?> GetProjectByIdAsync(long id)
    {
        return await _projectRepository.GetByIdWithTasksAsync(id);
    }

    public async Task<Project> CreateProjectAsync(Project project)
    {
        await _projectRepository.AddAsync(project);
        await _projectRepository.SaveChangesAsync();
        return project;
    }

    public async Task<Project> UpdateProjectAsync(Project project)
    {
        _projectRepository.Update(project);
        await _projectRepository.SaveChangesAsync();
        return project;
    }

    public async Task DeleteProjectAsync(long id)
    {
        var project = await _projectRepository.GetByIdWithTasksAsync(id);
        if (project != null)
        {
            _projectRepository.Delete(project);
            await _projectRepository.SaveChangesAsync();
        }
    }
}
