using ArrivalTracker.Data.Dtos.ExportDtos;

namespace ArrivalTracker.DataAccessServices;

public interface ITeamDataAccessService
{
    /// <summary>
    /// Get Team from the Database by given Name
    /// </summary>
    /// <param name="name">Name of the Team</param>
    /// <returns>TeamExportDto</returns>
    public TeamExportDto GetTeamByName(string name);
}
