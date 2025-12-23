using System.ComponentModel.DataAnnotations;

namespace BossNetCoreDemo.Web.DTOs;

public class CreateEmployeeDto
{
    [Required]
    public string Name { get; set; } = string.Empty;

    public decimal BasicPay { get; set; }
}
