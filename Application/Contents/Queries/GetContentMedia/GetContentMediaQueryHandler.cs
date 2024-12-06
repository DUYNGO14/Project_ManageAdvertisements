using Application.Contents.DTO;
using Application.Contents.Queries.GetAllContents;
using AutoMapper;
using Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Contents.Queries.GetContentMedia;

public class GetContentMediaQueryHandler(ILogger<GetAllContentQueryHandler> logger,
      IMapper mapper, IMediaRepository mediaRepository) : IRequestHandler<GetContentMediaQuery, List<MediaDto>>
{
    public async Task<List<MediaDto>> Handle(GetContentMediaQuery request, CancellationToken cancellationToken)
    {
        var medias = await mediaRepository.GetByContentId(request.ContentId);

        var mediaDtos = new List<MediaDto>();

        foreach (var item in medias)
        {
            var media = mapper.Map<MediaDto>(item);
            mediaDtos.Add(media);
        }
        return mediaDtos;
    }
}