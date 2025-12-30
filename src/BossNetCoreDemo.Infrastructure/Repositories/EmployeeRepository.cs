using BossNetCoreDemo.Application.Interfaces;
using BossNetCoreDemo.Domain.Entities;
using BossNetCoreDemo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BossNetCoreDemo.Infrastructure.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly AppDbContext _context;

    public EmployeeRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Employee> GetAll()
    {
        return _context.Employees.AsNoTracking().ToList();
    }

    public Employee? GetById(int id)
    {
        return _context.Employees.AsNoTracking()
            .FirstOrDefault(e => e.Id == id);
    }

    public void Add(Employee employee)
    {
        _context.Employees.Add(employee);
        _context.SaveChanges();
    }

    public void Update(Employee employee)
    {
        _context.Employees.Update(employee);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var entity = _context.Employees.Find(id);
        if (entity == null) return;

        _context.Employees.Remove(entity);
        _context.SaveChanges();
    }

    public IEnumerable<Employee> Search(
        string? keyword,
        int page,
        int pageSize,
        out int totalCount)
    {
        var query = _context.Employees.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(keyword))
        {
            query = query.Where(e => e.Name.Contains(keyword));
        }

        totalCount = query.Count();

        return query
            .OrderBy(e => e.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();
    }
}
