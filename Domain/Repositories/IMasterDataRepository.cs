using Domain.Constants;
using Domain.Entities;

namespace Domain.Repositories;

public interface IMasterDataRepository
{
    Task<IEnumerable<Location>> GetAllLocations();
    Task<IEnumerable<Location>> GetLocations(int? floor, string department);
    Task<IEnumerable<DeviceType>> GetAllDeviceTypes();
    Task<IEnumerable<TimeSlot>> GetAllTimeSlots();
    Task<(List<FloorDeviceResult>, List<DepartmentDeviceResult>)> GetOptionSelectLocations(string[] deviceType);
}
