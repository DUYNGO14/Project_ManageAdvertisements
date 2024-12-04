using Application.Contents.DTO;
using AutoMapper;
using Domain.Exceptions;
using Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Contents.Queries.GetContentById;

public class GetContentByIdQueryHandler(ILogger<GetContentByIdQueryHandler> logger, IContentRepository contentRepository, IMapper mapper) : IRequestHandler<GetContentByIdQuery, ContentDto>
{
    public async Task<ContentDto> Handle(GetContentByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting content with id : {@contentId}", request.Id);
        var content = await contentRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException("Content", request.Id.ToString());

        var contentdto = mapper.Map<ContentDto>(content);
        return contentdto;
    }
}
