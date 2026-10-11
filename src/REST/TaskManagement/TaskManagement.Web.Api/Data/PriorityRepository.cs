using Microsoft.EntityFrameworkCore;

namespace AnishCeDev.TaskManagement.Web.Api.Data;

public sealed class PriorityRepository(TaskManagementDbContext context) : EfRepository<PriorityEntity>(context)
{
    protected override DbSet<PriorityEntity> Entities => Context.Priorities;
    protected override PriorityEntity? FindTracked(long id) => Context.Priorities.Local.FirstOrDefault(x => x.PriorityId == id);
}
