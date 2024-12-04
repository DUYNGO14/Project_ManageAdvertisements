using AutoMapper;
using Domain.Entities;

namespace Application.Contents.DTO;

public class MediasProfile : Profile
{
    public MediasProfile()
    {
        CreateMap<MediaDto, Media>().ReverseMap();
        CreateMap<CreateMediaDto, Media>();
    }
}
