﻿using AutoMapper;
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
                .ForMember(d => d.Description, opt => opt.MapFrom(src => src.Location!.Description));
                
            CreateMap<Schedule,DeScheduleDto>();

            CreateMap<DeviceDailyAvailability,DeviceDailyDto>();
          
        }
    
    }
}
