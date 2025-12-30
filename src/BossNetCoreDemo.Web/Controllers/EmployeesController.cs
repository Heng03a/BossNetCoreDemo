using Microsoft.AspNetCore.Mvc;
using BossNetCoreDemo.Application.Interfaces;
using BossNetCoreDemo.Domain.Entities;

namespace BossNetCoreDemo.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: /Employees
        public IActionResult Index(string? q, int page = 1)
{
    const int pageSize = 5;
    var employees = _employeeService.Search(q, page, pageSize, out var total);

    ViewBag.Query = q;
    ViewBag.Page = page;
    ViewBag.TotalPages = (int)Math.Ceiling(total / (double)pageSize);

    return View(employees);
}

        // GET: /Employees/Create
// GET: /Employees/Create
[HttpGet]
public IActionResult Create()
{
    return View();
}

// POST: /Employees/Create
[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Create(Employee employee)
{
    // TEMP DEBUG — FORCE VISIBILITY
    if (!ModelState.IsValid)
    {
        foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
        {
            Console.WriteLine("MODEL ERROR: " + error.ErrorMessage);
        }

        return View(employee);
    }

    Console.WriteLine("POST HIT: Name=" + employee.Name + ", Pay=" + employee.BasicPay);

    _employeeService.Add(employee);

    Console.WriteLine("EMPLOYEE SAVED");

    return RedirectToAction(nameof(Index));
   }


    // GET: Employees/Edit/5
    public IActionResult Edit(int id)
    {
        var employee = _employeeService.GetById(id);
        if (employee == null) return NotFound();
        return View(employee);
    }

    // POST: Employees/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Employee employee)
    {
        if (id != employee.Id) return BadRequest();

        if (!ModelState.IsValid)
            return View(employee);

        _employeeService.Update(employee);
        return RedirectToAction(nameof(Index));
    }
// GET: Employees/Delete/5
public IActionResult Delete(int id)
{
    var employee = _employeeService.GetById(id);
    if (employee == null) return NotFound();
    return View(employee);
}

// POST: Employees/Delete/5
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public IActionResult DeleteConfirmed(int id)
{
    _employeeService.Delete(id);
    return RedirectToAction(nameof(Index));
}

  }
}
