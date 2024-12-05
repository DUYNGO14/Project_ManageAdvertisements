using Application.MasterData.DTO;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.MasterData.Queries.GetAllLocations;

public class GetAllLocationQueryHandler(ILogger<GetAllLocationQueryHandler> logger,IMasterDataRepository masterDataRepository,IMapper mapper) : IRequestHandler<GetAllLocationsQuery, IEnumerable<LocationDTO>>
{

    public async Task<IEnumerable<LocationDTO>> Handle(GetAllLocationsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all locations");
        var locations = await masterDataRepository.GetAllLocations();
        return mapper.Map<IEnumerable<LocationDTO>>(locations);

    }
}
