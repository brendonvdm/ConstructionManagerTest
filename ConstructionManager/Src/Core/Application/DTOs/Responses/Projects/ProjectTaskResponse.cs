using System;
using Domain.Projects;

namespace Application.DTOs.Responses.Projects;

public class ProjectTaskResponse
{
    public long Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public TaskStatus Status { get; set; }
    public long ProjectId { get; set; }
}
