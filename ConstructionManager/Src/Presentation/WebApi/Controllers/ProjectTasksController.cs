using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Application.DTOs.Requests.Projects;
using Application.DTOs.Responses.Projects;
using Application.Services;
using Domain.Projects;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/projects/{projectId}/[controller]")]
public class ProjectTasksController : ControllerBase
{
    private readonly ProjectTaskService _taskService;
    private readonly IMapper _mapper;

    public ProjectTasksController(ProjectTaskService taskService, IMapper mapper)
    {
        _taskService = taskService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProjectTaskResponse>>> GetTasks(long projectId)
    {
        var tasks = await _taskService.GetTasksByProjectIdAsync(projectId);
        return Ok(_mapper.Map<IEnumerable<ProjectTaskResponse>>(tasks));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProjectTaskResponse>> GetTask(long projectId, long id)
    {
        var task = await _taskService.GetTaskByIdAsync(id);
        if (task == null || task.ProjectId != projectId)
        {
            return NotFound();
        }
        return Ok(_mapper.Map<ProjectTaskResponse>(task));
    }

    [HttpPost]
    public async Task<ActionResult<ProjectTaskResponse>> CreateTask(long projectId, [FromBody] CreateProjectTaskRequest request)
    {
        request.ProjectId = projectId;
        var createdTask = await _taskService.CreateTaskAsync(request);
        return CreatedAtAction(nameof(GetTask), 
            new { projectId, id = createdTask.Id }, 
            _mapper.Map<ProjectTaskResponse>(createdTask));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask(long projectId, long id, [FromBody] UpdateProjectTaskRequest request)
    {
        if (id != request.Id || projectId != request.ProjectId)
        {
            return BadRequest();
        }
        await _taskService.UpdateTaskAsync(request);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(long projectId, long id)
    {
        await _taskService.DeleteTaskAsync(id);
        return NoContent();
    }
}
