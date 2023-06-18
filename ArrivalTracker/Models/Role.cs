using System.ComponentModel.DataAnnotations;

namespace ArrivalTracker.Models;

public class Role
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = " Role Name is required.")]
    public string Name { get; set; }
}
