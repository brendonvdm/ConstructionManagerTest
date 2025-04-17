using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Application.DTOs.Requests.Projects;
using Application.DTOs.Responses.Projects;
using Application.Interfaces.Repositories;
using Domain.Projects;

namespace Application.Services;

public class ProjectTaskService
{
    private readonly IProjectTaskRepository _taskRepository;
    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;

    public ProjectTaskService(
        IProjectTaskRepository taskRepository, 
        IProjectRepository projectRepository,
        IMapper mapper)
    {
        _taskRepository = taskRepository;
        _projectRepository = projectRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProjectTaskResponse>> GetTasksByProjectIdAsync(long projectId)
    {
        var tasks = await _taskRepository.GetByProjectIdAsync(projectId);
        return _mapper.Map<IEnumerable<ProjectTaskResponse>>(tasks);
    }

    public async Task<ProjectTaskResponse?> GetTaskByIdAsync(long id)
    {
        var task = await _taskRepository.GetByIdAsync(id);
        return _mapper.Map<ProjectTaskResponse>(task);
    }

    public async Task<ProjectTaskResponse> CreateTaskAsync(CreateProjectTaskRequest request)
    {
        var task = _mapper.Map<ProjectTask>(request);
        await _taskRepository.AddAsync(task);
        await _taskRepository.SaveChangesAsync();
        return _mapper.Map<ProjectTaskResponse>(task);
    }

    public async Task UpdateTaskAsync(UpdateProjectTaskRequest request)
    {
        var task = _mapper.Map<ProjectTask>(request);
        _taskRepository.Update(task);
        await _taskRepository.SaveChangesAsync();
    }

    public async Task DeleteTaskAsync(long id)
    {
        var task = await _taskRepository.GetByIdAsync(id);
        if (task != null)
        {
            _taskRepository.Delete(task);
            await _taskRepository.SaveChangesAsync();
        }
    }
}
