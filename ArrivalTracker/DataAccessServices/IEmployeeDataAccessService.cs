using ArrivalTracker.Data.Dtos.ExportDtos;
using ArrivalTracker.Data.Dtos.ImportDtos;

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
    /// <summary>
    /// Add new Employee to the Database 
    /// </summary>
    /// <returns>The ID of the newly created employee</returns>
    public Task<int> CreateEmployeeAsync(EmployeeImportDto employeeImportDto);
}

