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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employee>()
            .Property(e => e.BasicPay)
            .HasPrecision(18, 2);
    }
}
