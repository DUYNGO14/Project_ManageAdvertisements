using Domain.Entities;

namespace Application.Contents.DTO;

public class ContentDto
{
    public int Id { get; set; }

    public string Title { get; set; } = default!;

    public string Description { get; set; } = default!;
    public List<MediaDto> MediaDtos { get; set; } = new();

    public string Status { get; set; } = default!;

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = default!;

    public DateTime? UpdatedAt { get; set; }
}
