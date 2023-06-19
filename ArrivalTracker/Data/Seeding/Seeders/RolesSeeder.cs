using ArrivalTracker.Data.Dtos.ImportDtos;
using ArrivalTracker.Models;
using Newtonsoft.Json;

namespace ArrivalTracker.Data.Seeding.Seeders;

public class RolesSeeder : ISeeder
{
    public const string RolesJsonPath = @"../ArrivalTracker/Data/Seeding/JsonData/Roles.json";
    public void Seed(ArrivalsDbContext dbContext, IServiceProvider serviceProvider)
    {
        if (dbContext.Roles.Any())
        {
            return;
        }

        var inputJson = File.ReadAllText(RolesJsonPath);
        var rolesToImport = JsonConvert.DeserializeObject<List<RolesImportDto>>(inputJson);

        var roles = new List<Role>();
        foreach (var item in rolesToImport)
        {
            var role = new Role
            {
                Name = item.Name
            };
            roles.Add(role);
        }
        dbContext.Roles.AddRange(roles);
        dbContext.SaveChanges();
    }
}
