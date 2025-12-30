using BossNetCoreDemo.Application.Interfaces;
using BossNetCoreDemo.Domain.Entities;

namespace BossNetCoreDemo.Application.Services;


public class EmployeeService : IEmployeeService
    {public IEnumerable<Employee> Search(string? keyword, int page, int pageSize, out int totalCount)
    {
        return _repository.Search(keyword, page, pageSize, out totalCount);
    }

    private readonly IEmployeeRepository _repository;

    public EmployeeService(IEmployeeRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Employee> GetAll()
    {
        return _repository.GetAll();
    }

    public Employee? GetById(int id)
    {
        return _repository.GetById(id);
    }

    public void Add(Employee employee)
    {
        _repository.Add(employee);
    }

    public void Update(Employee employee)
    {
        _repository.Update(employee);
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
    }
}
