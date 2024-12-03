using Application.Common;
using Application.Devices.DTO;
using AutoMapper;
using Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Devices.Queries.GetAllDevices;

public class GetAllDevicesQueryHandler(ILogger<GetAllDevicesQueryHandler> logger,IDeviceRepository deviceRepository, IMapper mapper) : IRequestHandler<GetAllDevicesQuery, PagedResult<DeviceDto>>
{
    public async Task<PagedResult<DeviceDto>> Handle(GetAllDevicesQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all devices");
       
        var (devices, totalCount) = await deviceRepository
            .GetAllMatchingAsync(
            request.DeviceType,
            request.Location,
            request.PageSize,
            request.PageNumber,
            request.SortBy,
            request.SortDirection);
        var deviesDto = mapper.Map<List<DeviceDto>>(devices);
        return new PagedResult<DeviceDto>(deviesDto, totalCount, request.PageSize, request.PageNumber);
    }
}

