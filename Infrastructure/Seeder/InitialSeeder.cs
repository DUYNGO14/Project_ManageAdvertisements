using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Seeders;
public interface IInitialSeeder
{
    Task Seed();
}
internal class InitialSeeder(
    TimeSlotSeeder timeSlotSeeder,
    LocationSeeder locationSeeder,
    DeviceSeeder deviceSeeder,
    UserSeeder userSeeder,
    DeviceTypeSeeder deviceTypeSeeder,
    IServiceProvider serviceProvider,
    AppDbContext dbContext) : IInitialSeeder
{
    public async Task Seed()
    {
        if (dbContext.Database.GetPendingMigrations().Any())
        {
            await dbContext.Database.MigrateAsync();
        }

        if (await dbContext.Database.CanConnectAsync())
        {
            await deviceTypeSeeder.Seed();
            await timeSlotSeeder.Seed();
            await locationSeeder.Seed();
            await deviceSeeder.Seed();
            await userSeeder.Seed(serviceProvider);
        }

    }
}

