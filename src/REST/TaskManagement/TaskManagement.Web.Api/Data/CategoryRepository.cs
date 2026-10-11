using Microsoft.EntityFrameworkCore;

namespace AnishCeDev.TaskManagement.Web.Api.Data;

public sealed class CategoryRepository(TaskManagementDbContext context) : EfRepository<CategoryEntity>(context)
{
    protected override DbSet<CategoryEntity> Entities => Context.Categories;
    protected override CategoryEntity? FindTracked(long id) => Context.Categories.Local.FirstOrDefault(x => x.CategoryId == id);
}
