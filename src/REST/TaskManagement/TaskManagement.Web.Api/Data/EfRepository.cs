using Microsoft.EntityFrameworkCore;

namespace AnishCeDev.TaskManagement.Web.Api.Data;

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
