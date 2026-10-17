using System.ComponentModel.DataAnnotations;

namespace AnishCeDev.TaskManagement.Web.Api.Data;

public sealed class UserEntity
{
    public long UserId { get; set; }
    [MaxLength(100)] public string Username { get; set; } = null!;
    [MaxLength(100)] public string Firstname { get; set; } = null!;
    [MaxLength(100)] public string Lastname { get; set; } = null!;
    [MaxLength(256)] public string Email { get; set; } = null!;
    public ICollection<TaskEntity> AssignedTasks { get; set; } = new List<TaskEntity>();
}
