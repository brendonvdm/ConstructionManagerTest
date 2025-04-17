using System.Threading;
using System.Threading.Tasks;
using Domain.Projects;
using Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Domain.Common;
using Infrastructure.Persistence.Seeds;

namespace Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects => Set<Project>();
        public DbSet<ProjectTask> ProjectTasks => Set<ProjectTask>();

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectTaskConfiguration());
            ProjectTaskSeeder.Seed(modelBuilder);
        }
    }
}