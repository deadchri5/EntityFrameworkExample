using efejemplo.Models;
using Microsoft.EntityFrameworkCore;

namespace efejemplo;

public class TasksContext: DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Models.Task> Tasks { get; set; }
    public TasksContext(DbContextOptions<TasksContext> dbContextOptions): base(dbContextOptions) {}
}