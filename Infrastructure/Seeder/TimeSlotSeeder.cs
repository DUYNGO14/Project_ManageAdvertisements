using Infrastructure.Data;
using Infrastructure.Seeder.DataSeed;

namespace Infrastructure.Seeders;


internal class TimeSlotSeeder(AppDbContext dbContext)
{
 
    public async Task Seed()
    {
        if (!dbContext.TimeSlots.Any())
        {
            dbContext.TimeSlots.AddRange(TimeSlotData.TimeSlots);
            dbContext.SaveChanges();
        }
    }
}
