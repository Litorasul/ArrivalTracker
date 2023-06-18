namespace ArrivalTracker.Data.Dtos.ImportDtos;

public class EmployeeImportDto
{
    public string Name { get; set; }
    public string SurName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public int? ManagerId { get; set; }
}
