using Dapper;
using Domain.Constants;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class DeviceRepository(AppDbContext dbContext) : IDeviceRepository
{
    public async Task<(List<Device>, int)> GetAllMatchingAsync(string? deviceType, string? location, int pageSize, int pageNumber, string? sortBy, SortDirection sortDirection)
    {
        deviceType = deviceType?.ToLower();
        location = location?.ToLower();
        //query
        var baseQuery = dbContext.Devices.Include(r => r.Location).Include(r => r.DeviceType).Include(r=>r.DeviceDailyAvailabilities)
            .Where(r => (deviceType == null && location == null)
                        || r.DeviceType.Name.ToLower().Contains(deviceType)

                        || r.Location.Description.ToLower().Contains(location));
        //total items
        var totalCount = await baseQuery.CountAsync();
        // sort
        if (sortBy != null)
        {
            var columsSelector = new Dictionary<string, Expression<Func<Device, object>>>
                {
                    {nameof(Device.DeviceName),r=>r.DeviceName},
                    {nameof(Device.DeviceType.Name),r=>r.DeviceType.Name},
                    {nameof(Device.DeviceType.Size),r=>r.DeviceType.Size},
                };
            var selectedColum = columsSelector[sortBy];
            baseQuery = sortDirection == SortDirection.Ascending
                ? baseQuery.OrderBy(selectedColum)
                : baseQuery.OrderByDescending(selectedColum);
        }
        else
        {
            baseQuery = baseQuery.OrderByDescending(r => r.Id);
        }
        //pagination
        var devies = await baseQuery.Skip(pageSize * (pageNumber - 1))
             .Take(pageSize).ToListAsync();
        return (devies, totalCount);
    }

    public async Task<Device?> GetByIdAsync(int id)
    {
        var device = await dbContext.Devices
                                    .Include(d => d.Location)
                                    .Include(d => d.DeviceType)
                                    .Include(d => d.DeviceSchedules)
                                    .Include(d => d.DeviceDailyAvailabilities)
                                    .FirstOrDefaultAsync(d => d.Id == id);
        return device;
    }
}
