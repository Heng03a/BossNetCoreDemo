using System.ComponentModel.DataAnnotations;

namespace BossNetCoreDemo.Domain.Entities;

public class Employee
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Employee name is required")]
    public string Name { get; set; } = string.Empty;

    [Range(0.01, double.MaxValue, ErrorMessage = "Basic Pay must be greater than 0")]
    public decimal BasicPay { get; set; }
}
