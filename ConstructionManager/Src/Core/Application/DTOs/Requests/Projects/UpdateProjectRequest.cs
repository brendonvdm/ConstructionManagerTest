namespace Application.DTOs.Requests.Projects;

public class UpdateProjectRequest
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
}
