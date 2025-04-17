using System;
using System.Collections.Generic;

namespace Application.Models.Projects;

public class ProjectDto
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
}
