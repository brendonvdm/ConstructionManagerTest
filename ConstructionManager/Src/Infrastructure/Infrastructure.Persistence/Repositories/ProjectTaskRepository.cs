using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Domain.Projects;
using Infrastructure.Persistence.Contexts;

namespace Infrastructure.Persistence.Repositories;

public class ProjectTaskRepository : GenericRepository<ProjectTask>, IProjectTaskRepository
{
    public ProjectTaskRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<ProjectTask>> GetByProjectIdAsync(long projectId)
    {
        return await GetAsync(t => t.ProjectId == projectId);
    }
}
