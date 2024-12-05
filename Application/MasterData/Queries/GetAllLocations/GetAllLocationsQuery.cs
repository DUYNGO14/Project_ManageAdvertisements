using Application.MasterData.DTO;
using MediatR;

namespace Application.MasterData.Queries.GetAllLocations;

public class GetAllLocationsQuery : IRequest<IEnumerable<LocationDTO>>
{
}
