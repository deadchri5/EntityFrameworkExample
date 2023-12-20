using efejemplo.Models;
using Microsoft.EntityFrameworkCore;

namespace efejemplo;

public class TasksContext: DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Models.Task> Tasks { get; set; }
    public TasksContext(DbContextOptions<TasksContext> dbContextOptions): base(dbContextOptions) {}

    // fluent api
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category> (c => {
            c.ToTable("Category");
            c.HasKey(p => p.CategoryId);
            c.Property(p => p.Name).IsRequired().HasMaxLength(150);
            c.Property(p => p.Description);
            c.Property(p => p.Effort).IsRequired();
        });

        modelBuilder.Entity<Models.Task> (task => {
            task.ToTable("Task");
            task.HasKey(p => p.TaskId);
            task
                .HasOne(p => p.Category)
                .WithMany(p => p.Tasks)
                .HasForeignKey(p => p.CategoryId);
            task.Property(p => p.Title).IsRequired().HasMaxLength(200);
            task.Property(p => p.Description).IsRequired();
            task.Property(p => p.TaskProperty);
            task.Property(p => p.DateCreation);
            task.Ignore(p => p.Resumen);
        });
    }
}