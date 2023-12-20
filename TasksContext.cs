using efejemplo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace efejemplo;

public class TasksContext: DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Models.Task> Tasks { get; set; }
    public TasksContext(DbContextOptions<TasksContext> dbContextOptions): base(dbContextOptions) {}

    // fluent api
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        // Seeds
        List<Category> initCategories = new List<Category>();
        initCategories.Add(new Category() {
            CategoryId = Guid.Parse("96c1a1ea-12f0-4c7b-b7f5-e0bfc5b372a7"),
            Name = "Tareas del hogar",
            Effort = 20,
            Description = "Categoria de hogar",
        });

        initCategories.Add(new Category() {
            CategoryId = Guid.Parse("4693fbd8-95f9-46cf-bc12-053d3be7fda2"),
            Name = "Tareas oficina",
            Effort = 50,
            Description = "Categoria de oficina",
        });

        modelBuilder.Entity<Category> (c => {
            c.ToTable("Category");
            c.HasKey(p => p.CategoryId);
            c.Property(p => p.Name).IsRequired().HasMaxLength(150);
            c.Property(p => p.Description);
            c.Property(p => p.Effort).IsRequired();
            c.HasData(initCategories);
        });

        //seeds
        List<Models.Task> initTasks = new List<Models.Task>();
        initTasks.Add(new Models.Task() {
            TaskId = Guid.Parse("2e5f01ad-a366-4c50-963e-35631715ea7b"),
            CategoryId = Guid.Parse("96c1a1ea-12f0-4c7b-b7f5-e0bfc5b372a7"),
            Title = "Tender la cama",
            Description = "Tender la cama hace que nos sitamos felices el resto del dia.",
            TaskProperty = Properties.LOW,
            DateCreation = DateTime.Now,
        });

        initTasks.Add(new Models.Task() {
            TaskId = Guid.Parse("c03ccaca-ea76-4c7c-94c9-c2e676fa3188"),
            CategoryId = Guid.Parse("4693fbd8-95f9-46cf-bc12-053d3be7fda2"),
            Title = "Terminar el algoritmo del trabajo",
            Description = "Hacer la tarea que se tiene en jira",
            TaskProperty = Properties.HIGH,
            DateCreation = DateTime.Now,
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
            task.HasData(initTasks);
        });
    }
}