using Microsoft.EntityFrameworkCore;

namespace AnishCeDev.TaskManagement.Web.Api.Data;

public sealed class TaskManagementDbContext(DbContextOptions<TaskManagementDbContext> options) : DbContext(options)
{
    public DbSet<PriorityEntity> Priorities => Set<PriorityEntity>();
    public DbSet<StatusEntity> Statuses => Set<StatusEntity>();
    public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();
    public DbSet<UserEntity> Users => Set<UserEntity>();
    public DbSet<TaskEntity> Tasks => Set<TaskEntity>();
    public DbSet<LinkEntity> Links => Set<LinkEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PriorityEntity>().ToTable("Priority").HasKey(x => x.PriorityId);
        modelBuilder.Entity<StatusEntity>().ToTable("Status").HasKey(x => x.StatusId);
        modelBuilder.Entity<CategoryEntity>().ToTable("Category").HasKey(x => x.CategoryId);
        modelBuilder.Entity<UserEntity>().ToTable("User").HasKey(x => x.UserId);
        modelBuilder.Entity<LinkEntity>(entity =>
        {
            entity.ToTable("Link");
            entity.HasKey(x => x.LinkId);
            entity.HasIndex(x => new { x.ParentType, x.ParentId }).HasDatabaseName("IX_Link_Parent");
        });
        modelBuilder.Entity<TaskEntity>(entity =>
        {
            entity.ToTable("Task");
            entity.HasKey(x => x.TaskId);
            entity.HasOne(x => x.Priority).WithMany(x => x.Tasks).HasForeignKey(x => x.PriorityId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(x => x.Status).WithMany(x => x.Tasks).HasForeignKey(x => x.StatusId).OnDelete(DeleteBehavior.Restrict);
            entity.HasMany(x => x.Categories).WithMany(x => x.Tasks).UsingEntity<Dictionary<string, object>>(
                "TaskCategory", right => right.HasOne<CategoryEntity>().WithMany().HasForeignKey("CategoryId"),
                left => left.HasOne<TaskEntity>().WithMany().HasForeignKey("TaskId"),
                join => join.HasKey("TaskId", "CategoryId"));
            entity.HasMany(x => x.Assignees).WithMany(x => x.AssignedTasks).UsingEntity<Dictionary<string, object>>(
                "TaskAssignee", right => right.HasOne<UserEntity>().WithMany().HasForeignKey("UserId"),
                left => left.HasOne<TaskEntity>().WithMany().HasForeignKey("TaskId"),
                join => join.HasKey("TaskId", "UserId"));
        });
    }
}
