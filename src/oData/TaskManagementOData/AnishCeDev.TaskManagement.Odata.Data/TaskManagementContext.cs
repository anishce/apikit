// ************************************************************************
// Copyright (c) 2025 AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

using System.Collections.Generic;
using System.Reflection.Emit;

namespace AnishCeDev.TaskManagement.Data
{
    public class TaskManagementContext
    {
        public TaskManagementContext(DbContextOptions<TaskManagementContext> options)
            : base(options)
        {
        }

        // DbSet properties for the aggregate/root entities
        public DbSet<TaskModel> Tasks { get; set; } = null!;
        public DbSet<CategoryModel> Categories { get; set; } = null!;
        public DbSet<PriorityModel> Priorities { get; set; } = null!;
        public DbSet<StatusModel> Statuses { get; set; } = null!;
        public DbSet<UserModel> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Set primary keys (if not using conventions)
            modelBuilder.Entity<TaskModel>().HasKey(t => t.TaskId);
            modelBuilder.Entity<CategoryModel>().HasKey(c => c.CategoryId);
            modelBuilder.Entity<PriorityModel>().HasKey(p => p.PriorityId);
            modelBuilder.Entity<StatusModel>().HasKey(s => s.StatusId);
            modelBuilder.Entity<UserModel>().HasKey(u => u.UserId);

            // Configure one-to-many (many-to-one) relationships for Priority and Status
            modelBuilder.Entity<TaskModel>()
                .HasOne(t => t.Priority)
                .WithMany() // No collection navigation on PriorityModel
                .HasForeignKey("PriorityId")   // using shadow property for foreign key
                .IsRequired();

            modelBuilder.Entity<TaskModel>()
                .HasOne(t => t.Status)
                .WithMany() // No collection navigation on StatusModel
                .HasForeignKey("StatusId")     // using shadow property for foreign key
                .IsRequired();

            // Configure many-to-many for Task.Categories with join table "TaskCategory"
            modelBuilder.Entity<TaskModel>()
                .HasMany(t => t.Categories)
                .WithMany()
                .UsingEntity(j => j.ToTable("TaskCategory"));

            // Configure many-to-many for Task.Assignees with join table "TaskAssignee"
            modelBuilder.Entity<TaskModel>()
                .HasMany(t => t.Assignees)
                .WithMany()
                .UsingEntity(j => j.ToTable("TaskAssignee"));

            // Configure owned collections for LinkModel in each owner entity

            // Task links
            modelBuilder.Entity<TaskModel>()
                .OwnsMany(t => t.Links, l =>
                {
                    l.ToTable("TaskLink");
                    l.WithOwner().HasForeignKey("TaskId");
                    l.Property<int>("Id");  // Shadow property as key
                    l.HasKey("Id");
                    l.Property(link => link.Rel).IsRequired().HasMaxLength(50);
                    l.Property(link => link.Href).IsRequired().HasMaxLength(500);
                    l.Property(link => link.Title).IsRequired().HasMaxLength(100);
                    l.Property(link => link.Type).IsRequired().HasMaxLength(50);
                });

            // Category links
            modelBuilder.Entity<CategoryModel>()
                .OwnsMany(c => c.Links, l =>
                {
                    l.ToTable("CategoryLink");
                    l.WithOwner().HasForeignKey("CategoryId");
                    l.Property<int>("Id");
                    l.HasKey("Id");
                    l.Property(link => link.Rel).IsRequired().HasMaxLength(50);
                    l.Property(link => link.Href).IsRequired().HasMaxLength(500);
                    l.Property(link => link.Title).IsRequired().HasMaxLength(100);
                    l.Property(link => link.Type).IsRequired().HasMaxLength(50);
                });

            // Priority links
            modelBuilder.Entity<PriorityModel>()
                .OwnsMany(p => p.Links, l =>
                {
                    l.ToTable("PriorityLink");
                    l.WithOwner().HasForeignKey("PriorityId");
                    l.Property<int>("Id");
                    l.HasKey("Id");
                    l.Property(link => link.Rel).IsRequired().HasMaxLength(50);
                    l.Property(link => link.Href).IsRequired().HasMaxLength(500);
                    l.Property(link => link.Title).IsRequired().HasMaxLength(100);
                    l.Property(link => link.Type).IsRequired().HasMaxLength(50);
                });

            // Status links
            modelBuilder.Entity<StatusModel>()
                .OwnsMany(s => s.Links, l =>
                {
                    l.ToTable("StatusLink");
                    l.WithOwner().HasForeignKey("StatusId");
                    l.Property<int>("Id");
                    l.HasKey("Id");
                    l.Property(link => link.Rel).IsRequired().HasMaxLength(50);
                    l.Property(link => link.Href).IsRequired().HasMaxLength(500);
                    l.Property(link => link.Title).IsRequired().HasMaxLength(100);
                    l.Property(link => link.Type).IsRequired().HasMaxLength(50);
                });

            // User links
            modelBuilder.Entity<UserModel>()
                .OwnsMany(u => u.Links, l =>
                {
                    l.ToTable("UserLink");
                    l.WithOwner().HasForeignKey("UserId");
                    l.Property<int>("Id");
                    l.HasKey("Id");
                    l.Property(link => link.Rel).IsRequired().HasMaxLength(50);
                    l.Property(link => link.Href).IsRequired().HasMaxLength(500);
                    l.Property(link => link.Title).IsRequired().HasMaxLength(100);
                    l.Property(link => link.Type).IsRequired().HasMaxLength(50);
                });
        }
    }
}
