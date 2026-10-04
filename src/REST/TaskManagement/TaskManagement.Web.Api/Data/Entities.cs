using System.ComponentModel.DataAnnotations;

namespace AnishCeDev.TaskManagement.Web.Api.Data;

public sealed class PriorityEntity
{
    public long PriorityId { get; set; }
    [MaxLength(200)] public string Name { get; set; } = null!;
    public int Ordinal { get; set; }
    public ICollection<TaskEntity> Tasks { get; set; } = new List<TaskEntity>();
}

public sealed class StatusEntity
{
    public long StatusId { get; set; }
    [MaxLength(200)] public string Name { get; set; } = null!;
    public int Ordinal { get; set; }
    public ICollection<TaskEntity> Tasks { get; set; } = new List<TaskEntity>();
}

public sealed class CategoryEntity
{
    public long CategoryId { get; set; }
    [MaxLength(200)] public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public ICollection<TaskEntity> Tasks { get; set; } = new List<TaskEntity>();
}

public sealed class UserEntity
{
    public long UserId { get; set; }
    [MaxLength(100)] public string Username { get; set; } = null!;
    [MaxLength(100)] public string Firstname { get; set; } = null!;
    [MaxLength(100)] public string Lastname { get; set; } = null!;
    [MaxLength(256)] public string Email { get; set; } = null!;
    public ICollection<TaskEntity> AssignedTasks { get; set; } = new List<TaskEntity>();
}

public sealed class TaskEntity
{
    public long TaskId { get; set; }
    [MaxLength(500)] public string Subject { get; set; } = null!;
    public DateTime? StartDate { get; set; }
    public DateTime? DueDate { get; set; }
    public DateTime? DateCompleted { get; set; }
    public long PriorityId { get; set; }
    public PriorityEntity Priority { get; set; } = null!;
    public long StatusId { get; set; }
    public StatusEntity Status { get; set; } = null!;
    public ICollection<CategoryEntity> Categories { get; set; } = new List<CategoryEntity>();
    public ICollection<UserEntity> Assignees { get; set; } = new List<UserEntity>();
}

public sealed class LinkEntity
{
    public long LinkId { get; set; }
    [MaxLength(50)] public string ParentType { get; set; } = null!;
    public long ParentId { get; set; }
    [MaxLength(100)] public string Rel { get; set; } = null!;
    [MaxLength(2000)] public string Href { get; set; } = null!;
    [MaxLength(200)] public string Title { get; set; } = null!;
    [MaxLength(100)] public string Type { get; set; } = null!;
}
