using ArrivalTracker.Data.Dtos.ImportDtos;
using ArrivalTracker.Models;
using Newtonsoft.Json;

namespace ArrivalTracker.Data.Seeding.Seeders;

public class TeamsSeeder : ISeeder
{
    public const string TeamsJsonPath = @"../ArrivalTracker/Data/Seeding/JsonData/Teams.json";
    public void Seed(ArrivalsDbContext dbContext, IServiceProvider serviceProvider)
    {
        if (dbContext.Teams.Any())
        {
            return;
        }
        var inputJson = File.ReadAllText(TeamsJsonPath);
        var teamsToImport = JsonConvert.DeserializeObject<List<TeamsImportDto>>(inputJson);

        var teams = new List<Team>();
        foreach (var item in teamsToImport)
        {
            var team = new Team
            {
                Name = item.Name
            };
            teams.Add(team);
        }
        dbContext.Teams.AddRange(teams);
        dbContext.SaveChanges();
    }
}
