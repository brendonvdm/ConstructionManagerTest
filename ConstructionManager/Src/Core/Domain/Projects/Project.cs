using System;
using System.Collections.Generic;
using Domain.Common;

namespace Domain.Projects
{
    public class Project : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();
    }
}
