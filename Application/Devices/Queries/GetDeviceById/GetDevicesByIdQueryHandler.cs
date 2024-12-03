using Application.Devices.DTO;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
namespace Application.Devices.Queries.GetDeviceById;

public class GetDevicesByIdQueryHandler(ILogger<GetDevicesByIdQueryHandler> logger, IDeviceRepository devicesRepository, IScheduleRepository scheduleRepository ,IMapper mapper) : IRequestHandler<GetDevicesByIdQuery, DeviceDto>
{
    public async Task<DeviceDto> Handle(GetDevicesByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting device by id with {@devicesId}", request.Id);
        var device = await devicesRepository.GetByIdAsync(request.Id)
               ?? throw new NotFoundException("Devices", request.Id.ToString());
        var deviceDto = mapper.Map<DeviceDto>(device);
        var Schedules = new List<Schedule>();
        foreach (var schedule in device.DeviceSchedules!) 
        { 
            var sch = await scheduleRepository.GetByIdAsync(schedule.ScheduleID);
            Schedules.Add(sch);
        }
        deviceDto.SchedulesDtos = mapper.Map<List<DeScheduleDto>>(Schedules);

        var deviceDaily = device.DeviceDailyAvailabilities?.ToList();
        deviceDto.DeviceDailyDtos = mapper.Map<List<DeviceDailyDto>>(deviceDaily);
        return deviceDto;
    }
}
