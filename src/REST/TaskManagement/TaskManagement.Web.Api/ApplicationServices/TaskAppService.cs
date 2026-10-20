using AnishCeDev.TaskManagement.Web.Api.Data;
using AnishCeDev.TaskManagement.Web.Api.Data.Repositories;
using AnishCeDev.TaskManagement.Web.Api.Models;

namespace AnishCeDev.TaskManagement.Web.Api.ApplicationServices;

public sealed class TaskAppService(TaskRepository tasks, LinkRepository links) : ITaskAppService
{
    public async Task<TaskModel> GetTaskAsync(int taskId)
    {
        var entity = await tasks.GetByIdAsync(taskId) ?? throw new KeyNotFoundException($"Task {taskId} was not found.");
        return await ToModelAsync(entity);
    }

    public async Task AddNewTaskAsync(TaskModel model)
    {
        var entity = model.ToEntity();
        await tasks.ReplaceRelationshipsAsync(entity, (model.Categories ?? []).Select(x => x.CategoryId), (model.Assignees ?? []).Select(x => x.UserId));
        entity = await tasks.AddAsync(entity);
        await links.ReplaceForParentAsync("Task", entity.TaskId, (model.Links ?? []).Select(x => x.ToEntity()));
    }

    public async Task<IEnumerable<TaskModel>> GetTasksAsync()
    {
        var result = new List<TaskModel>();
        foreach (var entity in await tasks.GetAllAsync()) result.Add(await ToModelAsync(entity));
        return result;
    }

    public async Task RemoveTaskAsync(int taskId)
    {
        await links.ReplaceForParentAsync("Task", taskId, []);
        await tasks.DeleteAsync(taskId);
    }

    public async Task UpdateTaskAsync(int taskId, TaskModel model)
    {
        var entity = await tasks.GetByIdAsync(taskId) ?? throw new KeyNotFoundException($"Task {taskId} was not found.");
        entity.Subject = model.Subject;
        entity.StartDate = model.StartDate;
        entity.DueDate = model.DueDate;
        entity.DateCompleted = model.DateCompleted;
        entity.PriorityId = model.Priority.PriorityId ?? 0;
        entity.StatusId = model.Status.StatusId;
        await tasks.ReplaceRelationshipsAsync(entity, (model.Categories ?? []).Select(x => x.CategoryId), (model.Assignees ?? []).Select(x => x.UserId));
        await tasks.UpdateAsync(entity);
        await links.ReplaceForParentAsync("Task", taskId, (model.Links ?? []).Select(x => x.ToEntity()));
    }

    private async Task<TaskModel> ToModelAsync(TaskEntity entity) => new()
    {
        TaskId = entity.TaskId,
        Subject = entity.Subject,
        StartDate = entity.StartDate,
        DueDate = entity.DueDate,
        DateCompleted = entity.DateCompleted,
        Priority = entity.Priority.ToModel(await links.GetByParentAsync("Priority", entity.PriorityId)),
        Status = entity.Status.ToModel(await links.GetByParentAsync("Status", entity.StatusId)),
        Categories = (await Task.WhenAll(entity.Categories.Select(async x => x.ToModel(await links.GetByParentAsync("Category", x.CategoryId))))).ToList(),
        Assignees = (await Task.WhenAll(entity.Assignees.Select(async x => x.ToModel(await links.GetByParentAsync("User", x.UserId))))).ToList(),
        Links = (await links.GetByParentAsync("Task", entity.TaskId)).Select(x => x.ToModel()).ToList()
    };
}
