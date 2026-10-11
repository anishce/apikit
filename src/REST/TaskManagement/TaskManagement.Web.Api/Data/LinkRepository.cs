using Microsoft.EntityFrameworkCore;

namespace AnishCeDev.TaskManagement.Web.Api.Data;

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
