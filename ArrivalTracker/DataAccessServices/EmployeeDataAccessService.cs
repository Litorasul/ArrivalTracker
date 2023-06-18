using ArrivalTracker.Data;
using ArrivalTracker.Data.Dtos.ExportDtos;
using ArrivalTracker.Data.Dtos.ImportDtos;
using ArrivalTracker.Models;

namespace ArrivalTracker.DataAccessServices;

public class EmployeeDataAccessService : IEmployeeDataAccessService
{
    private readonly ArrivalsDbContext _context;
    private readonly IRoleDataAccessService _roleDataAccessService;
    public EmployeeDataAccessService(ArrivalsDbContext context, IRoleDataAccessService roleDataAccessService)
    {
        _context = context;
        _roleDataAccessService = roleDataAccessService;
    }

    public EmployeeExportDto GetEmployeeById(int id)
    {
        var employee = _context.Employees.Where(e => e.Id == id).FirstOrDefault();
        if (employee == null)
             throw new NullReferenceException($"Employee with ID - {id} does not exist in the Database!");
        
        
        return new EmployeeExportDto
        {
            Id = employee.Id,
            Name = employee.Name,
            SurName = employee.SurName,
            Role = GetRoleName(employee.RoleId),
            Email = employee.Email,
            ManagerId = employee.ManagerId,
        };
    }

    public EmployeeExportDto GetEmployeeByNameAndSurname(string name, string surname)
    {
        var employee = _context.Employees.Where(e => e.Name == name && e.SurName == surname).FirstOrDefault();
        if (employee == null)
             throw new NullReferenceException($"Employee with Name - {name} and Surname - {surname} does not exist in the Database!");
        
        
        return new EmployeeExportDto
        {
            Id = employee.Id,
            Name = employee.Name,
            SurName = employee.SurName,
            Role = GetRoleName(employee.RoleId),
            Email = employee.Email,
            ManagerId = employee.ManagerId,
        };
    }

    public async Task<int> CreateEmployeeAsync(EmployeeImportDto employeeImportDto)
    {
        var employee = new Employee
        {
            Name = employeeImportDto.Name,
            SurName= employeeImportDto.SurName,
            RoleId = GetRoleId(employeeImportDto.Role),
            Email = employeeImportDto.Email,
            ManagerId= employeeImportDto.ManagerId
        };
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
        return employee.Id;
    }

    private string GetRoleName(int roleId)
    {
        var role = _roleDataAccessService.GetRoleById(roleId);
        return role.Name;
    }

    private int GetRoleId(string roleName)
    {
        var role = _roleDataAccessService.GetRoleByName(roleName);
        return role.Id;
    }
}
