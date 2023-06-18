using ArrivalTracker.Data.Dtos.ExportDtos;

namespace ArrivalTracker.DataAccessServices;

public interface IEmployeeDataAccessService
{
    /// <summary>
    /// Gets Employee from the Database by given Name and Surname
    /// </summary>
    /// <returns>EmployeeExportDto</returns>
     public EmployeeExportDto GetEmployeeByNameAndSurname(string name, string surname);
    /// <summary>
    /// Gets Employee from the Database by given ID 
    /// </summary>
    /// <returns>EmployeeExportDto</returns>
    public EmployeeExportDto GetEmployeeById(int id);
}

