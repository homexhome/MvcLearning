using Microsoft.EntityFrameworkCore;
using MvcStartApp.Context;
using MvcStartApp.Repository;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Options;
using MvcLearning.Middleware;

var builder = WebApplication.CreateBuilder(args);

string connString0 = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<BlogContext>(options => options.UseSqlServer(connString0));

// Add services to the container.
builder.Services.AddControllersWithViews();

// Регистрация сервиса репозитория
builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope()) {
    var serviceProvider = scope.ServiceProvider;
    var blogContext = serviceProvider.GetRequiredService<BlogContext>();

    Console.WriteLine("Creating databases and tables...");

    blogContext.Database.EnsureDeleted();

    blogContext.Database.EnsureCreated();

    Console.WriteLine("Databases and tables creation completed.");
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseMiddleware<LoggingMiddleware>();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
       name: "logs",
       pattern: "Logs",
       defaults: new { controller = "Request", action = "Logs" });

app.Run();
