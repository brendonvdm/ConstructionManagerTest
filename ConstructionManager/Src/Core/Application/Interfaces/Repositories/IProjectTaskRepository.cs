using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Projects;

namespace Application.Interfaces.Repositories;

public interface IProjectTaskRepository : IGenericRepository<ProjectTask>
{
    Task<IEnumerable<ProjectTask>> GetByProjectIdAsync(long projectId);
}
