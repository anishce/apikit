using Microsoft.EntityFrameworkCore;

namespace AnishCeDev.TaskManagement.Web.Api.Data;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(long id, CancellationToken cancellationToken = default);
}

public abstract class EfRepository<TEntity>(TaskManagementDbContext context) : IRepository<TEntity> where TEntity : class
{
    protected TaskManagementDbContext Context { get; } = context;
    protected abstract DbSet<TEntity> Entities { get; }
    protected abstract TEntity? FindTracked(long id);

    public virtual async Task<TEntity?> GetByIdAsync(long id, CancellationToken cancellationToken = default) =>
        await Entities.FindAsync([id], cancellationToken);

    public virtual async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await Entities.AsNoTracking().ToListAsync(cancellationToken);

    public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await Entities.AddAsync(entity, cancellationToken);
        await Context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        Entities.Update(entity);
        await Context.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task DeleteAsync(long id, CancellationToken cancellationToken = default)
    {
        var entity = FindTracked(id) ?? await GetByIdAsync(id, cancellationToken);
        if (entity is null) return;
        Entities.Remove(entity);
        await Context.SaveChangesAsync(cancellationToken);
    }
}

public sealed class PriorityRepository(TaskManagementDbContext context) : EfRepository<PriorityEntity>(context)
{
    protected override DbSet<PriorityEntity> Entities => Context.Priorities;
    protected override PriorityEntity? FindTracked(long id) => Context.Priorities.Local.FirstOrDefault(x => x.PriorityId == id);
}

public sealed class StatusRepository(TaskManagementDbContext context) : EfRepository<StatusEntity>(context)
{
    protected override DbSet<StatusEntity> Entities => Context.Statuses;
    protected override StatusEntity? FindTracked(long id) => Context.Statuses.Local.FirstOrDefault(x => x.StatusId == id);
}

public sealed class CategoryRepository(TaskManagementDbContext context) : EfRepository<CategoryEntity>(context)
{
    protected override DbSet<CategoryEntity> Entities => Context.Categories;
    protected override CategoryEntity? FindTracked(long id) => Context.Categories.Local.FirstOrDefault(x => x.CategoryId == id);
}

public sealed class UserRepository(TaskManagementDbContext context) : EfRepository<UserEntity>(context)
{
    protected override DbSet<UserEntity> Entities => Context.Users;
    protected override UserEntity? FindTracked(long id) => Context.Users.Local.FirstOrDefault(x => x.UserId == id);
}

public sealed class LinkRepository(TaskManagementDbContext context) : EfRepository<LinkEntity>(context)
{
    protected override DbSet<LinkEntity> Entities => Context.Links;
    protected override LinkEntity? FindTracked(long id) => Context.Links.Local.FirstOrDefault(x => x.LinkId == id);

    public async Task<IReadOnlyList<LinkEntity>> GetByParentAsync(string parentType, long parentId, CancellationToken cancellationToken = default) =>
        await Context.Links.AsNoTracking().Where(x => x.ParentType == parentType && x.ParentId == parentId).ToListAsync(cancellationToken);

    public async Task ReplaceForParentAsync(string parentType, long parentId, IEnumerable<LinkEntity> links, CancellationToken cancellationToken = default)
    {
        var existing = await Context.Links.Where(x => x.ParentType == parentType && x.ParentId == parentId).ToListAsync(cancellationToken);
        Context.Links.RemoveRange(existing);
        foreach (var link in links)
        {
            link.LinkId = 0;
            link.ParentType = parentType;
            link.ParentId = parentId;
        }
        await Context.Links.AddRangeAsync(links, cancellationToken);
        await Context.SaveChangesAsync(cancellationToken);
    }
}

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
