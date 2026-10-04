using AnishCeDev.TaskManagement.Web.Api.Data;
using AnishCeDev.TaskManagement.Web.Api.Models;

namespace AnishCeDev.TaskManagement.Web.Api.ApplicationServices;

internal static class EntityModelMapper
{
    public static LinkEntity ToEntity(this LinkModel model) => new() { Rel = model.Rel, Href = model.Href, Title = model.Title, Type = model.Type };
    public static LinkModel ToModel(this LinkEntity entity) => new() { Rel = entity.Rel, Href = entity.Href, Title = entity.Title, Type = entity.Type };
    public static CategoryEntity ToEntity(this CategoryModel model) => new() { CategoryId = model.CategoryId, Name = model.Name, Description = model.Description };
    public static CategoryModel ToModel(this CategoryEntity entity, IEnumerable<LinkEntity> links) => new() { CategoryId = entity.CategoryId, Name = entity.Name, Description = entity.Description, Links = links.Select(ToModel).ToList() };
    public static PriorityEntity ToEntity(this PriorityModel model) => new() { PriorityId = model.PriorityId ?? 0, Name = model.Name, Ordinal = model.Ordinal };
    public static PriorityModel ToModel(this PriorityEntity entity, IEnumerable<LinkEntity> links) => new() { PriorityId = entity.PriorityId, Name = entity.Name, Ordinal = entity.Ordinal, Links = links.Select(ToModel).ToList() };
    public static StatusEntity ToEntity(this StatusModel model) => new() { StatusId = model.StatusId, Name = model.Name, Ordinal = model.Ordinal };
    public static StatusModel ToModel(this StatusEntity entity, IEnumerable<LinkEntity> links) => new() { StatusId = entity.StatusId, Name = entity.Name, Ordinal = entity.Ordinal, Links = links.Select(ToModel).ToList() };
    public static UserEntity ToEntity(this UserModel model) => new() { UserId = model.UserId, Username = model.Username, Firstname = model.Firstname, Lastname = model.Lastname, Email = model.Email };
    public static UserModel ToModel(this UserEntity entity, IEnumerable<LinkEntity> links) => new() { UserId = entity.UserId, Username = entity.Username, Firstname = entity.Firstname, Lastname = entity.Lastname, Email = entity.Email, Links = links.Select(ToModel).ToList() };
    public static TaskEntity ToEntity(this TaskModel model) => new() { TaskId = model.TaskId, Subject = model.Subject, StartDate = model.StartDate, DueDate = model.DueDate, DateCompleted = model.DateCompleted, PriorityId = model.Priority.PriorityId ?? 0, StatusId = model.Status.StatusId };
}
