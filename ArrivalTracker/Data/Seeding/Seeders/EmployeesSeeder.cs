using ArrivalTracker.Data.Dtos.ImportDtos;
using ArrivalTracker.DataAccessServices;
using ArrivalTracker.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ArrivalTracker.Data.Seeding.Seeders;

public class EmployeesSeeder : ISeeder
{
    public const string EmployeesJsonPath = @"../ArrivalTracker/Data/Seeding/JsonData/Employees.json";

    public void Seed(ArrivalsDbContext dbContext, IServiceProvider serviceProvider)
    {
        if (dbContext.Employees.Any())
        { return; }

        var inputJson = File.ReadAllText(EmployeesJsonPath);
        var employeesToImport = JsonConvert.DeserializeObject<List<EmployeeImportDto>>(inputJson);
        var roleDataAccessService = new RoleDataAccessService(dbContext);

        var employees = new List<Employee>();
        foreach (var item in employeesToImport)
        {
            var role = new Employee
            {
                Name = item.Name,
                SurName = item.SurName,
                RoleId = roleDataAccessService.GetRoleByName(item.Role).Id,
                ManagerId = item.ManagerId
            };
            employees.Add(role);
        }
        dbContext.Employees.AddRange(employees);
        dbContext.SaveChanges();
    }
}
