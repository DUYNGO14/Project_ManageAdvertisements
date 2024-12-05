using Application.MasterData.DTO;
using Domain.Entities;
using MediatR;

namespace Application.MasterData.Queries.GetAllDeviceTypes;

public class GetAllDeviceTypesQuery : IRequest<IEnumerable<DeviceTypeDTO>>
{
}
