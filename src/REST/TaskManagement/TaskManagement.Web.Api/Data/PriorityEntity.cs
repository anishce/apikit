using System.ComponentModel.DataAnnotations;

namespace AnishCeDev.TaskManagement.Web.Api.Data;

public sealed class PriorityEntity
{
    public long PriorityId { get; set; }
    [MaxLength(200)] public string Name { get; set; } = null!;
    public int Ordinal { get; set; }
    public ICollection<TaskEntity> Tasks { get; set; } = new List<TaskEntity>();
}
