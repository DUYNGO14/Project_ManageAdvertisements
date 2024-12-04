using Application.Contents.DTO;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Contents.Command.CreateMedia;

public class UploadMediaCommand : IRequest<List<MediaDto>>
{
    public IFormFile Chunk { get; set; }
    public string FileName { get; set; }
    public int ChunkIndex { get; set; }
    public int TotalChunks { get; set; }
    public string FileType { get; set; }
    public int FileSize { get; set; }
    public int Duration { get; set; }
    public string Resolution { get; set; }

}
