using System;
using Domain.Common;

namespace Domain.Projects
{
    public class ProjectTask : BaseEntity
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public TaskStatus Status { get; set; } = TaskStatus.NotStarted;
        public long ProjectId { get; set; }
        public Project? Project { get; set; }
    }

    public enum TaskStatus
    {
        NotStarted,
        InProgress,
        Completed
    }
}
