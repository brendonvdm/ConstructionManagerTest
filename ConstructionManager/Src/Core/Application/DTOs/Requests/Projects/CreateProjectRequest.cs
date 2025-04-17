namespace Application.DTOs.Requests.Projects;

public class CreateProjectRequest
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}
