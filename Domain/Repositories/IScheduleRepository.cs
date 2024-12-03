using Domain.Entities;

namespace Domain.Repositories;

public interface IScheduleRepository
{
    Task<Schedule> GetByIdAsync(int id);
}
