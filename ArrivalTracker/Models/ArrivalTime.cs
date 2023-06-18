using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArrivalTracker.Models;

public class ArrivalTime
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Employee is required.")]
    [ForeignKey("Employee")]
    public int EmployeeId { get; set; }
    [Required(ErrorMessage = "Arrival time is required.")]
    public DateTime Arrival {get; set; }
}
