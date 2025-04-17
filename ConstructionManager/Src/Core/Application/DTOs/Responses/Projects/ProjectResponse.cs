using System;

namespace Application.DTOs.Responses.Projects;

public class ProjectResponse
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
}
