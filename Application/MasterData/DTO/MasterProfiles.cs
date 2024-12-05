using AutoMapper;
using Domain.Entities;

namespace Application.MasterData.DTO;

public class MasterProfiles : Profile
{
    public MasterProfiles()
    {
        CreateMap<DeviceType,DeviceTypeDTO>().ReverseMap();
        CreateMap<Location,LocationDTO>().ReverseMap();
        CreateMap<TimeSlot,TimeSlotDto>()
            .ForMember(d=>d.IsPeak, src=>src.MapFrom(opt =>opt.IsPeak == true?"YES":"NO")).ReverseMap();
    }
}
