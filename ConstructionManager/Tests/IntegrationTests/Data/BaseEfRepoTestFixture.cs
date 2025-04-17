using Application.Interfaces;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests.Data
{
    public abstract class BaseEfRepoTestFixture
    {
        protected ApplicationDbContext dbContext;

        protected BaseEfRepoTestFixture()
        {
            var options = CreateNewContextOptions();
            dbContext = new ApplicationDbContext(options);
        }

        protected static DbContextOptions<ApplicationDbContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseInMemoryDatabase(nameof(ApplicationDbContext))
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        protected GenericRepository<T> GetRepository<T>() where T : class
        {
            return new GenericRepository<T>(dbContext);
        }
    };
}
