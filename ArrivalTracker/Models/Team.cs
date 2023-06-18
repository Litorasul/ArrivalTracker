using System.ComponentModel.DataAnnotations;

namespace ArrivalTracker.Models;

public class Team
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Team Name is required.")]
    public string Name { get; set; }
}
