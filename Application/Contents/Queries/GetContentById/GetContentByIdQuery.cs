using Application.Contents.DTO;
using MediatR;

namespace Application.Contents.Queries.GetContentById;

public class GetContentByIdQuery(int id) : IRequest<ContentDto>
{
    public int Id { get; } = id;
}
