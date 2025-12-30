using BossNetCoreDemo.Domain.Entities;

namespace BossNetCoreDemo.Application.Interfaces;

public interface IEmployeeRepository
{
    IEnumerable<Employee> GetAll();
    Employee? GetById(int id);

    void Add(Employee employee);
    void Update(Employee employee);
    void Delete(int id);

    IEnumerable<Employee> Search(
        string? keyword,
        int page,
        int pageSize,
        out int totalCount);
}
