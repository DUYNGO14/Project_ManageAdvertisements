using Infrastructure.Data;
using Infrastructure.Seeder.DataSeed;

namespace Infrastructure.Seeders;

internal class DeviceTypeSeeder(AppDbContext dbContext)
{
    public async Task Seed()
    {
        if (!dbContext.DeviceTypes.Any())
        {
            dbContext.DeviceTypes.AddRange(DeviceTypeData.deviceTypes);
            dbContext.SaveChanges();
        }
    }
}
