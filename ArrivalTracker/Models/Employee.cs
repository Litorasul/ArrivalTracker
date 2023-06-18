using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArrivalTracker.Models;

public class Employee
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Employee Name is required.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Surname is required.")]
    public string SurName { get; set; }
    [Required(ErrorMessage = "Email is required.")]
    public string Email { get; set; }
    [ForeignKey("Role")]
    public int RoleId { get; set; }
    [ForeignKey("Employee")]
    public int? ManagerId { get; set; }
}
