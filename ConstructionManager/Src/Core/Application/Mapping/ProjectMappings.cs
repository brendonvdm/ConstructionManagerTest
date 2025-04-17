using AutoMapper;
using Application.DTOs.Requests.Projects;
using Application.DTOs.Responses.Projects;
using Domain.Projects;

namespace Application.Mapping;

public class ProjectMappings : Profile
{
    public ProjectMappings()
    {
        // Request to Domain
        CreateMap<CreateProjectRequest, Project>();
        CreateMap<UpdateProjectRequest, Project>();
        CreateMap<CreateProjectTaskRequest, ProjectTask>();
        CreateMap<UpdateProjectTaskRequest, ProjectTask>();
        
        // Domain to Response
        CreateMap<Project, ProjectResponse>();
        CreateMap<ProjectTask, ProjectTaskResponse>();
    }
}
