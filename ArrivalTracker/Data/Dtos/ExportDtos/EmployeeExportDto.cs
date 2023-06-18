namespace ArrivalTracker.Data.Dtos.ExportDtos;

public class EmployeeExportDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string SurName { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public int? ManagerId { get; set; }

}
