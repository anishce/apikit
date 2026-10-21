using Microsoft.EntityFrameworkCore;

namespace AnishCeDev.TaskManagement.Web.Api.Data.Repositories;

public sealed class StatusRepository(TaskManagementDbContext context) : EfRepository<StatusEntity>(context)
{
    protected override DbSet<StatusEntity> Entities => Context.Statuses;
    protected override StatusEntity? FindTracked(long id) => Context.Statuses.Local.FirstOrDefault(x => x.StatusId == id);
}
