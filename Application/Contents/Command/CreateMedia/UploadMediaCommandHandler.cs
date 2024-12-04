using Application.Common;
using Application.Contents.DTO;
using Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Hosting;

namespace Application.Contents.Command.CreateMedia;

public class UploadMediaCommandHandler(IWebHostEnvironment webHostEnvironment, IBackgroundServiceQueue backgroundServiceQueue) : IRequestHandler<UploadMediaCommand, List<MediaDto>>
{
    public async Task<List<MediaDto>> Handle(UploadMediaCommand request, CancellationToken cancellationToken)
    {
        var chunkFolder = Path.Combine(webHostEnvironment.WebRootPath, "uploads", "chunks");
        Directory.CreateDirectory(chunkFolder);

        if (request.Chunk == null || string.IsNullOrEmpty(request.FileName) || request.TotalChunks <= 0)
        {
            throw new Exception("Upload chunk failed");
        }

        var chunkFilePath = Path.Combine(chunkFolder, $"{request.FileName}.part{request.ChunkIndex}");

        // Save the chunk
        using (var fileStream = new FileStream(chunkFilePath, FileMode.Create))
        {
            await request.Chunk.CopyToAsync(fileStream, cancellationToken);
        }

        List<MediaDto> mediaDtos = new List<MediaDto>();

        // If this is the last chunk, queue the task for merging in the background
        if (request.ChunkIndex + 1 == request.TotalChunks)
        {
            var mergeJob = new MergeJob
            {
                FileName = request.FileName,
                TotalChunks = request.TotalChunks,
                ChunkFolder = chunkFolder,
                Type = request.FileType,
                Size = request.FileSize,
                Duration = request.Duration,
                Resolution = request.Resolution,
                CompletionSource = new TaskCompletionSource<List<MediaDto>>()
            };

            // Queue the job for the background service
            await backgroundServiceQueue.QueueMergeJob(mergeJob);

            // Wait for the merge to complete and get the list of merged paths
            mediaDtos = await mergeJob.CompletionSource.Task;
        }

        return mediaDtos;
    }
}