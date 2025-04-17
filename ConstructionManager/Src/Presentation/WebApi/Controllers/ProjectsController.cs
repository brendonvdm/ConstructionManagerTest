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
[Route("[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly ProjectService _projectService;
    private readonly IMapper _mapper;

    public ProjectsController(ProjectService projectService, IMapper mapper)
    {
        _projectService = projectService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProjectResponse>>> GetAll()
    {
        var projects = await _projectService.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<ProjectResponse>>(projects));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProjectResponse>> GetById(long id)
    {
        var project = await _projectService.GetProjectByIdAsync(id);
        if (project == null)
        {
            return NotFound();
        }
        return Ok(_mapper.Map<ProjectResponse>(project));
    }

    [HttpPost]
    public async Task<ActionResult<ProjectResponse>> Create([FromBody] CreateProjectRequest request)
    {
        var project = _mapper.Map<Project>(request);
        var createdProject = await _projectService.CreateProjectAsync(project);
        return CreatedAtAction(nameof(GetById),
            new { id = createdProject.Id },
            _mapper.Map<ProjectResponse>(createdProject));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] UpdateProjectRequest request)
    {
        if (id != request.Id)
        {
            return BadRequest();
        }

        var project = _mapper.Map<Project>(request);
        await _projectService.UpdateProjectAsync(project);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _projectService.DeleteProjectAsync(id);
        return NoContent();
    }
}
