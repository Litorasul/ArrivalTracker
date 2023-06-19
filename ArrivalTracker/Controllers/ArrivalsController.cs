using ArrivalTracker.Data.Dtos.ImportDtos;
using Microsoft.AspNetCore.Mvc;

namespace ArrivalTracker.Controllers;

[Route("api/arrive")]
[ApiController]
public class ArrivalsController : ControllerBase
{
    [HttpPost]
    public IResult Post([FromBody] List<ArrivalTimeImportDto> arrivals)
    {
        return Results.Ok(arrivals);
    }

}
