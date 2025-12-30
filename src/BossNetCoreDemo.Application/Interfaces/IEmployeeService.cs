using BossNetCoreDemo.Domain.Entities;

namespace BossNetCoreDemo.Application.Interfaces;

public interface IEmployeeService
{
    IEnumerable<Employee> GetAll();
    IEnumerable<Employee> Search(string? keyword, int page, int pageSize, out int totalCount);

    Employee? GetById(int id);

    void Add(Employee employee);
    void Update(Employee employee);
    void Delete(int id);
}
