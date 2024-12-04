using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ScheduleRepository(AppDbContext dbContext) : IScheduleRepository
{
    public async Task<Schedule?> GetByIdAsync(int id)
    {
        var schedule = await dbContext.Schedules
                                    .Include(s => s.Content)
                                    .ThenInclude(c => c.Media)
                                    .FirstOrDefaultAsync(r => r.Id == id);
        return schedule;
    }
}
