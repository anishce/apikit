using System.ComponentModel.DataAnnotations;

namespace AnishCeDev.TaskManagement.Web.Api.Data;

public sealed class StatusEntity
{
    public long StatusId { get; set; }
    [MaxLength(200)] public string Name { get; set; } = null!;
    public int Ordinal { get; set; }
    public ICollection<TaskEntity> Tasks { get; set; } = new List<TaskEntity>();
}
