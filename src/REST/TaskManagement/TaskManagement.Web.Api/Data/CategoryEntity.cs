using System.ComponentModel.DataAnnotations;

namespace AnishCeDev.TaskManagement.Web.Api.Data;

public sealed class CategoryEntity
{
    public long CategoryId { get; set; }
    [MaxLength(200)] public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public ICollection<TaskEntity> Tasks { get; set; } = new List<TaskEntity>();
}
