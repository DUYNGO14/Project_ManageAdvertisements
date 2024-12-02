using Infrastructure.Data;
using Infrastructure.Seeder.DataSeed;

namespace Infrastructure.Seeders
{
    internal class LocationSeeder(AppDbContext dbContext)
    {
        public async Task Seed()
        {
            if (!dbContext.Locations.Any())
            {
                dbContext.Locations.AddRange(LocationData.Locations);
                dbContext.SaveChanges();
            }
        }

    }

}
