
using ContextAwareEFCore;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ContextInfo>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("DemoDb"));

var app = builder.Build();

app.Use(async (context, next) =>
{
    var contextInfo = context.RequestServices.GetRequiredService<ContextInfo>();
    // Simulating context population
    contextInfo.UserId = context.Request.Headers["X-User-Id"];
    contextInfo.IsAdmin = context.Request.Headers["X-Is-Admin"] == "true";
    await next();
});

app.MapGet("/orders", async (AppDbContext db) =>
    await db.Orders.ToListAsync());

app.MapPost("/orders", async (AppDbContext db, Order order) =>
{
    db.Orders.Add(order);
    await db.SaveChangesAsync();
    return Results.Created($"/orders/{order.Id}", order);
});

app.Run();
