using BossNetCoreDemo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using BossNetCoreDemo.Application.Interfaces;
using BossNetCoreDemo.Application.Services;
using BossNetCoreDemo.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
Console.WriteLine(
    builder.Configuration.GetConnectionString("DefaultConnection")
);

// MVC
builder.Services.AddControllersWithViews();

// DbContext (Infrastructure only)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Dependency Injection
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

var app = builder.Build();

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
