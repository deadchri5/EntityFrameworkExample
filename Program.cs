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

app.MapGet("/api/getTasks", async ([FromServices] TasksContext dbContext) => {
    // return Results.Ok(dbContext.Tasks.Where(p => p.TaskProperty == efejemplo.Models.Properties.LOW));
    var tasks = await dbContext.Tasks.Include(p => p.Category).ToListAsync();
    return Results.Ok(tasks);
});

app.Run();
