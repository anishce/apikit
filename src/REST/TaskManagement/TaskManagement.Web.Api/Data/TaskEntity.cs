using System.ComponentModel.DataAnnotations;

namespace AnishCeDev.TaskManagement.Web.Api.Data;

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
