namespace BossNetCoreDemo.Domain.Entities;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal BasicPay { get; set; }
}
