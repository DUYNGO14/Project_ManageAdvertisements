using Application.Contents.DTO;
using MediatR;

namespace Application.Contents.Queries.GetContentMedia;

public class GetContentMediaQuery(int contentId) : IRequest<List<MediaDto>>
{
    public int ContentId { get; set; } = contentId;
}
