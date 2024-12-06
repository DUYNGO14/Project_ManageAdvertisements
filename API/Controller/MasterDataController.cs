using Application.MasterData.DTO;
using Application.MasterData.Queries.GetAllDeviceTypes;
using Application.MasterData.Queries.GetAllLocations;
using Application.MasterData.Queries.GetAllTimeSlots;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller;


[ApiController]
public class MasterDataController(IMediator mediator) : ControllerBase
{
    [HttpGet("api/locations")]
    public async Task<ActionResult<IEnumerable<LocationDTO>>> GetAllLocations([FromQuery] GetAllLocationsQuery query)
    {
        var results = await mediator.Send(query);
        return Ok(results);
    }

    [HttpGet("api/timeslots")]
    public async Task<ActionResult<IEnumerable<TimeSlotDto>>> GetAllTimeslots([FromQuery] GetAllTimeSlotsQuery query)
    {
        var results = await mediator.Send(query);
        return Ok(results);
    }

    [HttpGet("api/device_type")]
    public async Task<ActionResult<IEnumerable<DeviceTypeDTO>>> GetAllDevice_type([FromQuery] GetAllDeviceTypesQuery query)
    {
        var results = await mediator.Send(query);
        return Ok(results);
    }

}
