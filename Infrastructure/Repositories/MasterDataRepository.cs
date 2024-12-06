using Domain.Constants;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class MasterDataRepository(AppDbContext dbContext) : IMasterDataRepository
{
    public async Task<IEnumerable<DeviceType>> GetAllDeviceTypes()
    {
        return await dbContext.DeviceTypes.AsNoTracking().ToListAsync();
    }

    public async Task<IEnumerable<Location>> GetAllLocations()
    {
        return await dbContext.Locations.AsNoTracking().ToListAsync();
    }

    public async Task<IEnumerable<TimeSlot>> GetAllTimeSlots()
    {
        return await dbContext.TimeSlots.AsNoTracking().ToListAsync();
    }

    public Task<(List<FloorDeviceResult>, List<DepartmentDeviceResult>)> GetOptionSelectLocations(string[] deviceType)
    {
        throw new NotImplementedException();
    }
}
