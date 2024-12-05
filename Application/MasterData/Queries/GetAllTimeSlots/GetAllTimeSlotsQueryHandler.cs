using Application.MasterData.DTO;
using AutoMapper;
using Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.MasterData.Queries.GetAllTimeSlots;

public class GetAllTimeSlotsQueryHandler(ILogger<GetAllTimeSlotsQueryHandler> logger, IMasterDataRepository masterDataRepository,IMapper mapper) : IRequestHandler<GetAllTimeSlotsQuery, IEnumerable<TimeSlotDto>>
{
    public async Task<IEnumerable<TimeSlotDto>> Handle(GetAllTimeSlotsQuery request, CancellationToken cancellationToken)
    {

        logger.LogInformation("Getting all time slot");
        var timeslots = await masterDataRepository.GetAllTimeSlots();
        return mapper.Map<IEnumerable<TimeSlotDto>>(timeslots);
    }
}
