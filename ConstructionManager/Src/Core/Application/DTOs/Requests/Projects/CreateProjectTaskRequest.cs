using Domain.Projects;

namespace Application.DTOs.Requests.Projects;

public class CreateProjectTaskRequest
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public TaskStatus Status { get; set; }
    public long ProjectId { get; set; }
}
