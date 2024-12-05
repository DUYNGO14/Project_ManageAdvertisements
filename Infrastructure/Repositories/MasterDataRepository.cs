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


    public async Task<IEnumerable<Location>> GetLocations(int? floor, string department)
    {
        //if (floor.HasValue && floor.Value > 0)
        //{
        //    return await dbContext.Locations.Where(l => l.Floor == floor).ToListAsync();
        //}
        //if (!string.IsNullOrWhiteSpace(department))
        //{
        //    return await dbContext.Locations.Where(l => l.Department.ToLower().Equals(department.ToLower())).ToListAsync();
        //}
        //if ((floor.HasValue && floor.Value > 0) && !string.IsNullOrWhiteSpace(department))
        //{
        //    return await dbContext.Locations.Where(l => l.Department.ToLower().Equals(department.ToLower()) && l.Floor == floor).ToListAsync();
        //}
        //return await this.GetAllLocations();
        return await dbContext.Locations.AsNoTracking().ToListAsync();
    }

    public Task<(List<FloorDeviceResult>, List<DepartmentDeviceResult>)> GetOptionSelectLocations(string[] deviceType)
    {
        throw new NotImplementedException();
    }
}
