using ArrivalTracker.Data;
using ArrivalTracker.Data.Dtos.ExportDtos;

namespace ArrivalTracker.DataAccessServices;

public class RoleDataAccessService : IRoleDataAccessService
{
    private readonly ArrivalsDbContext _context;
    public RoleDataAccessService(ArrivalsDbContext context)
    {
        _context = context;
    }

    public RoleExportDto GetRoleById(int id)
    {
        var role = _context.Roles.Where(r => r.Id == id).FirstOrDefault();
        if (role == null)
            throw new NullReferenceException($"Role with ID - {id} - does not exist in the Database!");

        return new RoleExportDto
        {
            Id = role.Id, Name = role.Name
        };
    }

    public RoleExportDto GetRoleByName(string name)
    {
        var role = _context.Roles.Where(r => r.Name == name).FirstOrDefault();
        if (role == null)
            throw new NullReferenceException($"Role with Name - {name} - does not exist in the Database!");

        return new RoleExportDto
        {
            Id = role.Id, Name = role.Name
        };
    }
}
