using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Projects;

namespace Application.Interfaces.Repositories;

public interface IProjectRepository : IGenericRepository<Project>
{
    Task<Project?> GetByIdWithTasksAsync(long id);
}
