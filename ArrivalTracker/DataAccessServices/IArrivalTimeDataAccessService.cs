using ArrivalTracker.Data.Dtos.ExportDtos;
using ArrivalTracker.Data.Dtos.ImportDtos;

namespace ArrivalTracker.DataAccessServices;

public interface IArrivalTimeDataAccessService
{
    /// <summary>
    /// Gets all arrival times from the Database by given employee ID
    /// </summary>
    /// <returns>List of ArrivalTimeExportDto</returns>
    public List<ArrivalTimeExportDto> GetAllArrivalTimeByEmployeeId(int employeeId);
    /// <summary>
    /// Add a new arrival time for an Employee
    /// </summary>
    /// <returns>the ID of the newly created Arrival time</returns>
    public Task<int> CreateNewArrivalTimeForEmployeeAsync(ArrivalTimeImportDto arrivalTimeImportDto);
}
