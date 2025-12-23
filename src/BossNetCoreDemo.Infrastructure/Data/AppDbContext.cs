using BossNetCoreDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BossNetCoreDemo.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employees => Set<Employee>();
}
