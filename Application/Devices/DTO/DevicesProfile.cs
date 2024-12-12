using AutoMapper;
using Domain.Entities;

namespace Application.Devices.DTO
{
    public class DevicesProfile : Profile
    {
        public DevicesProfile()
        {

            CreateMap<Device, DeviceDto>()
                .ForMember(d => d.Size, opt => opt.MapFrom(src => src.DeviceType!.Size))
                .ForMember(d => d.DeviceType, opt => opt.MapFrom(src => src.DeviceType!.Name))
                .ForMember(d => d.Resolution, opt => opt.MapFrom(src => src.DeviceType!.Resolution))
                .ForMember(d => d.Description, opt => opt.MapFrom(src => src.Location!.Description))
                .ForMember(d => d.DeviceDailyDtos, opt => opt.MapFrom(src => src.DeviceDailyAvailabilities!.ToList()));

            CreateMap<Schedule,DeScheduleDto>();

            CreateMap<DeviceDailyAvailability,DeviceDailyDto>();

            CreateMap<DeviceDailyTimeSlot, DeviceDailyTimeSlotDTO>()
                .ForMember(d => d.TimeSlot, src => src.MapFrom(opt => $"{opt.TimeSlot.StartTime} - {opt.TimeSlot.EndTime}"))
                .ForMember(d=>d.TypeTime, src => src.MapFrom(opt => opt.TimeSlot.IsPeak == true ? "GOLD":"NORMAL"));

        }
    }
}
