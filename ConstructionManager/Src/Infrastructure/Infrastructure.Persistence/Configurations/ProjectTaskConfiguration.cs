using Domain.Projects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ProjectTaskConfiguration : IEntityTypeConfiguration<ProjectTask>
{
    public void Configure(EntityTypeBuilder<ProjectTask> builder)
    {
        builder.ToTable("ProjectTasks");
        
        builder.Property(t => t.Title)
            .IsRequired()
            .HasMaxLength(200);
            
        builder.Property(t => t.Description)
            .HasMaxLength(1000);
            
        builder.Property(t => t.Status)
            .HasConversion<string>()
            .HasDefaultValue(TaskStatus.NotStarted);
    }
}
