using Application.Devices.DTO;
using MediatR;

namespace Application.Devices.Queries.GetDeviceById;

public class GetDevicesByIdQuery(int devicesId) : IRequest<DeviceDto>
{
    public int Id { get; } = devicesId;
}
