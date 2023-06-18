using ArrivalTracker.Data.Dtos.ExportDtos;

namespace ArrivalTracker.DataAccessServices;

public interface IRoleDataAccessService
{
    /// <summary>
    /// Get Role from the Database by given Name
    /// </summary>
    /// <param name="name">Name of the role</param>
    /// <returns>RoleExportDto</returns>
     public RoleExportDto GetRoleByName(string name);
    /// <summary>
    /// Get Role from the Database by given Id
    /// </summary>
    /// <param name="id">Id of the Role in the Database</param>
    /// <returns>RoleExportDto</returns>
    public RoleExportDto GetRoleById(int id);
}
