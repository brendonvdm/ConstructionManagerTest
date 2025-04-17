using System;
using System.Collections.Generic;
using Domain.Projects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Seeds;

public static class ProjectTaskSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        // Seed Projects
        var projects = new List<Project>
        {
            new Project { Id = 1, Name = "Office Building Construction", Description = "New corporate headquarters", CreatedAt = new DateTime(2025, 1, 1) },
            new Project { Id = 2, Name = "Residential Complex", Description = "50-unit apartment building", CreatedAt = new DateTime(2025, 1, 1) },
            new Project { Id = 3, Name = "Road Infrastructure", Description = "Highway expansion project", CreatedAt = new DateTime(2025, 1, 1) }
        };

        // Seed Tasks for each Project
        var tasks = new List<ProjectTask>
        {
            // Tasks for Project 1
            new ProjectTask { Id = 1, ProjectId = 1, Title = "Site Preparation", Description = "Clear and grade the site", Status = TaskStatus.NotStarted },
            new ProjectTask { Id = 2, ProjectId = 1, Title = "Foundation Work", Description = "Pour concrete foundation", Status = TaskStatus.NotStarted },
            new ProjectTask { Id = 3, ProjectId = 1, Title = "Structural Framing", Description = "Erect steel structure", Status = TaskStatus.NotStarted },

            // Tasks for Project 2
            new ProjectTask { Id = 4, ProjectId = 2, Title = "Excavation", Description = "Dig foundations", Status = TaskStatus.NotStarted },
            new ProjectTask { Id = 5, ProjectId = 2, Title = "Utilities Installation", Description = "Install plumbing and electrical", Status = TaskStatus.NotStarted },
            new ProjectTask { Id = 6, ProjectId = 2, Title = "Interior Finishes", Description = "Drywall and flooring", Status = TaskStatus.NotStarted },

            // Tasks for Project 3
            new ProjectTask { Id = 7, ProjectId = 3, Title = "Surveying", Description = "Mark road alignment", Status = TaskStatus.NotStarted },
            new ProjectTask { Id = 8, ProjectId = 3, Title = "Grading", Description = "Prepare roadbed", Status = TaskStatus.NotStarted },
            new ProjectTask { Id = 9, ProjectId = 3, Title = "Paving", Description = "Lay asphalt surface", Status = TaskStatus.NotStarted }
        };

        modelBuilder.Entity<Project>().HasData(projects);
        modelBuilder.Entity<ProjectTask>().HasData(tasks);
    }
}
