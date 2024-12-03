using Application.Devices.DTO;
using AutoMapper;
using Domain.Entities;


namespace Application.Schedules.DTO
{
    public class SchedulesProfile : Profile
    {
        public SchedulesProfile()
        {
            CreateMap<Schedule, SchedulesDto>();
            //CreateMap<CreateScheduleCommand, Schedule>();
           
        }
    }
}
