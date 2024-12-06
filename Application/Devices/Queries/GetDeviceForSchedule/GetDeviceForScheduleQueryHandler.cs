using Application.Devices.DTO;
using AutoMapper;
using Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Devices.Queries.GetDeviceForSchedule;

public class GetDeviceForScheduleQueryHandler(ILogger<GetDeviceForScheduleQueryHandler> logger , IMapper mapper, IDeviceRepository deviceRepository) : IRequestHandler<GetDeviceForScheduleQuery, IEnumerable<DeviceDto>>
{
    public Task<IEnumerable<DeviceDto>> Handle(GetDeviceForScheduleQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
