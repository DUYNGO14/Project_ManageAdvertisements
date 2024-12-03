using Application.Common;
using Application.Devices.DTO;
using Domain.Constants;
using MediatR;

namespace Application.Devices.Queries.GetAllDevices;

public class GetAllDevicesQuery : IRequest<PagedResult<DeviceDto>>
{
    public string? DeviceType { get; set; }
    public string? Location { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SortBy { get; set; } = "DeviceName";
    public SortDirection SortDirection { get; set; } = SortDirection.Ascending;
}
