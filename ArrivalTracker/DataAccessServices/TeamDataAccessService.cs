using ArrivalTracker.Data;
using ArrivalTracker.Data.Dtos.ExportDtos;

namespace ArrivalTracker.DataAccessServices;

public class TeamDataAccessService : ITeamDataAccessService
{
    private readonly ArrivalsDbContext _context;
    public TeamDataAccessService(ArrivalsDbContext context)
    {
        _context = context;
    }
    public TeamExportDto GetTeamByName(string name)
    {
        var team = _context.Teams.Where(t => t.Name == name).FirstOrDefault();
        if (team == null)
             throw new NullReferenceException($"Team with Name - {name} - does not exist in the Database!");

        return new TeamExportDto
        {
            Id = team.Id, Name = team.Name
        };
    }
}
