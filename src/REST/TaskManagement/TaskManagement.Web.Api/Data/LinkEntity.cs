using System.ComponentModel.DataAnnotations;

namespace AnishCeDev.TaskManagement.Web.Api.Data;

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
