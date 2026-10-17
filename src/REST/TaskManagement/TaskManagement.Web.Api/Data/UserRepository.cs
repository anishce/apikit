using Microsoft.EntityFrameworkCore;

namespace AnishCeDev.TaskManagement.Web.Api.Data;

public sealed class UserRepository(TaskManagementDbContext context) : EfRepository<UserEntity>(context)
{
    protected override DbSet<UserEntity> Entities => Context.Users;
    protected override UserEntity? FindTracked(long id) => Context.Users.Local.FirstOrDefault(x => x.UserId == id);
}
