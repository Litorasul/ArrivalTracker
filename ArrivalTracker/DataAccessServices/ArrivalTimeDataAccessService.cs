using ArrivalTracker.Data;
using ArrivalTracker.Data.Dtos.ExportDtos;
using ArrivalTracker.Data.Dtos.ImportDtos;
using ArrivalTracker.Models;

namespace ArrivalTracker.DataAccessServices;

public class ArrivalTimeDataAccessService : IArrivalTimeDataAccessService
{
    private readonly ArrivalsDbContext _context;
    public ArrivalTimeDataAccessService(ArrivalsDbContext context)
    {
        _context = context;
    }
    public async Task<int> CreateNewArrivalTimeForEmployeeAsync(ArrivalTimeImportDto arrivalTimeImportDto)
    {
        var arrivalTime = new ArrivalTime
        {
            EmployeeId = arrivalTimeImportDto.EmployeeId,
            Arrival = arrivalTimeImportDto.Arrival
        };
        await _context.ArrivalTimes.AddAsync(arrivalTime);
        await _context.SaveChangesAsync();
        return arrivalTime.Id;
    }

    public List<ArrivalTimeExportDto> GetAllArrivalTimeByEmployeeId(int employeeId)
    {
        var arrivalTimes = _context.ArrivalTimes.Where(a => a.EmployeeId == employeeId).Select(a => new ArrivalTimeExportDto
        {
            Id = a.Id,
            EmployeeId = a.EmployeeId,
            Arrival = a.Arrival
        }).ToList();
        return arrivalTimes;
    }
}
