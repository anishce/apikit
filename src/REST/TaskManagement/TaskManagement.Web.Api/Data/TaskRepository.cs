using Microsoft.EntityFrameworkCore;

namespace AnishCeDev.TaskManagement.Web.Api.Data;

public sealed class TaskRepository(TaskManagementDbContext context) : EfRepository<TaskEntity>(context)
{
    protected override DbSet<TaskEntity> Entities => Context.Tasks;
    protected override TaskEntity? FindTracked(long id) => Context.Tasks.Local.FirstOrDefault(x => x.TaskId == id);

    public override Task<TaskEntity?> GetByIdAsync(long id, CancellationToken cancellationToken = default) =>
        Context.Tasks.Include(x => x.Priority).Include(x => x.Status).Include(x => x.Categories).Include(x => x.Assignees)
            .SingleOrDefaultAsync(x => x.TaskId == id, cancellationToken);

    public override async Task<IReadOnlyList<TaskEntity>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await Context.Tasks.AsNoTracking().Include(x => x.Priority).Include(x => x.Status).Include(x => x.Categories).Include(x => x.Assignees).ToListAsync(cancellationToken);

    public async Task ReplaceRelationshipsAsync(TaskEntity task, IEnumerable<long> categoryIds, IEnumerable<long> assigneeIds, CancellationToken cancellationToken = default)
    {
        task.Categories = await Context.Categories.Where(x => categoryIds.Contains(x.CategoryId)).ToListAsync(cancellationToken);
        task.Assignees = await Context.Users.Where(x => assigneeIds.Contains(x.UserId)).ToListAsync(cancellationToken);
    }

    public override async Task DeleteAsync(long id, CancellationToken cancellationToken = default)
    {
        var task = await GetByIdAsync(id, cancellationToken);
        if (task is null) return;
        task.Categories.Clear();
        task.Assignees.Clear();
        await Context.SaveChangesAsync(cancellationToken);
        Context.Tasks.Remove(task);
        await Context.SaveChangesAsync(cancellationToken);
    }
}
