using Application.Contents.Command.CreateContents;
using AutoMapper;
using Domain.Entities;

namespace Application.Contents.DTO;

public class ContentsProfile : Profile
{
    public ContentsProfile()
    {
        CreateMap<CreateContentCommand, Content>();
        CreateMap<Content, ContentDto>()
            .ForMember(d=>d.MediaDtos, src =>src.MapFrom(opt => opt.Media.ToList()));
    }
}
