using Application.MasterData.DTO;
using MediatR;

namespace Application.MasterData.Queries.GetAllTimeSlots;

public class GetAllTimeSlotsQuery : IRequest<IEnumerable<TimeSlotDto>>
{
}
