using Domain.Constants;
using Domain.Entities;

namespace Domain.Repositories;

public interface IMasterDataRepository
{
    Task<IEnumerable<Location>> GetAllLocations();
    Task<IEnumerable<DeviceType>> GetAllDeviceTypes();
    Task<IEnumerable<TimeSlot>> GetAllTimeSlots();
 
    Task<(List<FloorDeviceResult>, List<DepartmentDeviceResult>)> GetOptionSelectLocations(string[] deviceType);
}
