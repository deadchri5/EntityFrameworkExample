using efejemplo;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// add memory database service to builder
// builder.Services.AddDbContext<TasksContext>(p => p.UseInMemoryDatabase("TaskDB"));
// add sql server service to builder
builder.Services.AddSqlServer<TasksContext>(builder.Configuration.GetSection("Server")["ConnectionString"]);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// new endpoint
app.MapGet("/dbConnection", async ([FromServices] TasksContext dbContext) => {
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria " + dbContext.Database.IsInMemory());
});

app.MapGet("/api/getTasks", async (TasksContext dbContext) => {
    // return Results.Ok(dbContext.Tasks.Where(p => p.TaskProperty == efejemplo.Models.Properties.LOW));
    var tasks = await dbContext.Tasks.Include(p => p.Category).ToListAsync();
    return Results.Ok(tasks);
});

app.MapPost("/api/postTask", async (TasksContext dbContext, efejemplo.Models.Task task) => {

    task.TaskId = Guid.NewGuid();
    task.DateCreation = DateTime.Now;

    await dbContext.AddAsync(task);

    await dbContext.SaveChangesAsync();

    return Results.Ok();
});

app.MapPut("/api/editTask/{id}", async (TasksContext dbContext, efejemplo.Models.Task task, [FromRoute] Guid id) => {
    
    var findTask = dbContext.Tasks.Find(id);

    if (findTask != null) {
        findTask.Category = task.Category;
        findTask.Title = task.Title;
        findTask.Description = task.Description;
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }

    return Results.NotFound();
});

app.MapDelete("/api/deleteTask/{id}", async (TasksContext dbContext, [FromRoute] Guid id) => {
    
    var findTask = dbContext.Tasks.Find(id);

    if (findTask != null) {
        dbContext.Remove(findTask);
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }

    return Results.NotFound();
});

app.Run();
