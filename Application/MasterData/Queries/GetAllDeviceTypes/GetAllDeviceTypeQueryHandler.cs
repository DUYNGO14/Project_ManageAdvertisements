using Application.MasterData.DTO;
using AutoMapper;
using Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.MasterData.Queries.GetAllDeviceTypes;

public class GetAllDeviceTypeQueryHandler(ILogger<GetAllDeviceTypeQueryHandler> logger, IMasterDataRepository masterDataRepository,IMapper mapper) : IRequestHandler<GetAllDeviceTypesQuery, IEnumerable<DeviceTypeDTO>>
{

    public async Task<IEnumerable<DeviceTypeDTO>> Handle(GetAllDeviceTypesQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all device types");
        var type = await masterDataRepository.GetAllDeviceTypes();
        return mapper.Map<IEnumerable<DeviceTypeDTO>>(type);
    }
}
