using ArrivalTracker.Data.Dtos.ImportDtos;
using ArrivalTracker.DataAccessServices;
using Microsoft.AspNetCore.Mvc;

namespace ArrivalTracker.Controllers;

[Route("api/arrive")]
[ApiController]
public class ArrivalsController : ControllerBase
{
    private readonly IArrivalTimeDataAccessService _dataAccessService;
    public ArrivalsController(IArrivalTimeDataAccessService dataAccessService)
    {
        _dataAccessService = dataAccessService;
    }

    [HttpPost]
    public async Task<IResult> Post([FromBody] List<ArrivalTimeImportDto> arrivals)
    {
        if (arrivals == null || arrivals.Count == 0)
        {
            return Results.BadRequest();
        }
        foreach (var item in arrivals)
        {
            await _dataAccessService.CreateNewArrivalTimeForEmployeeAsync(item);
        }
        return Results.Ok();
    }

}
