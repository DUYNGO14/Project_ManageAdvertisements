using Domain.Constants;
using Domain.Entities;

namespace Domain.Repositories;

public interface IDeviceRepository
{
    Task<(List<Device>, int)> GetAllMatchingAsync(string? deviceType,string? location, int pageSize, int pagenumber, string? sortBy, SortDirection sortDirection);
    Task<Device?> GetByIdAsync(int id);
    Task<List<Device>> GetDeviceForSchedule(string location, string DeviceType,DateTime StartDate,DateTime EndDate, int TotalDuration);
}
