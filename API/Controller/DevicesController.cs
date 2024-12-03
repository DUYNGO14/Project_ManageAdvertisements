using Application.Devices.DTO;
using Application.Devices.Queries.GetAllDevices;
using Application.Devices.Queries.GetDeviceById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller;

[Route("api/[controller]")]
[ApiController]
public class DevicesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllDevices([FromQuery] GetAllDevicesQuery query)
    {
        var result = await mediator.Send(query);
        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<DeviceDto>> GetDevicesById([FromRoute] int id)
    {
        var devices = await mediator.Send(new GetDevicesByIdQuery(id));
        return Ok(devices);
    }

}
