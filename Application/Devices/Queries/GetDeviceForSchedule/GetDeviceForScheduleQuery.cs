using Application.Devices.DTO;
using MediatR;

namespace Application.Devices.Queries.GetDeviceForSchedule;

public class GetDeviceForScheduleQuery : IRequest<IEnumerable<DeviceDto>>
{
    public string DeviceType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int TotalDuration { get; set; }
}
