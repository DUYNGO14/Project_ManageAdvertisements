using Application.Common;
using Application.Contents.DTO;
using Domain.Constants;
using MediatR;

namespace Application.Contents.Queries.GetAllContents;

public class GetAllContentQuery : IRequest<PagedResult<ContentDto>>
{
    public string? SearchPhrase { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SortBy { get; set; } = "CreatedAt";
    public SortDirection SortDirection { get; set; } = SortDirection.Ascending;
}
