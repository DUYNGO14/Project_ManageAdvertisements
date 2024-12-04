using Application.Common;
using Application.Contents.DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Application.Interfaces;

public class FileMergeService : BackgroundService
{
    private readonly IBackgroundServiceQueue _queue;
    private readonly ILogger<FileMergeService> _logger;
    private readonly IHostApplicationLifetime _hostApplicationLifetime;
    public FileMergeService(IBackgroundServiceQueue queue, ILogger<FileMergeService> logger, IHostApplicationLifetime hostApplicationLifetime, IWebHostEnvironment webHostEnvironment)
    {
        _queue = queue;
        _logger = logger;
        _hostApplicationLifetime = hostApplicationLifetime;

    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var mergeJob = await _queue.DequeueAsync(stoppingToken);

                await MergeChunks(mergeJob, stoppingToken);

            }
            catch (OperationCanceledException)
            {
                break;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the merge job.");
            }
        }
    }


    private async Task MergeChunks(MergeJob mergeJob, CancellationToken stoppingToken)
    {
        var parentFolder = Directory.GetParent(mergeJob.ChunkFolder).FullName;
        var uniqueFileName = $"{Path.GetFileNameWithoutExtension(mergeJob.FileName)}_{Guid.NewGuid()}{Path.GetExtension(mergeJob.FileName)}";
        var finalFilePath = Path.Combine(parentFolder, uniqueFileName);
        var relFilePath = Path.Combine("uploads", uniqueFileName);
        List<MediaDto> output = new List<MediaDto>();

        try
        {
            using (var finalFileStream = new FileStream(finalFilePath, FileMode.Create))
            {
                var chunkedFiles = Directory.EnumerateFiles(mergeJob.ChunkFolder, $"{mergeJob.FileName}.part*")
    .OrderBy(f => int.Parse(Path.GetExtension(f).Replace(".part", "")));
                foreach (var chunkFile in chunkedFiles)
                {
                    using (var chunkStream = new FileStream(chunkFile, FileMode.Open))
                    {
                        await chunkStream.CopyToAsync(finalFileStream, 81920, stoppingToken);
                    }
                    File.Delete(chunkFile);
                }
            }

            Directory.Delete(mergeJob.ChunkFolder, recursive: true);
            MediaDto mediaDto = new MediaDto()
            {
                FileName = uniqueFileName,
                Type = mergeJob.Type,
                Path = relFilePath,
                Size = mergeJob.Size,
                Duration = mergeJob.Duration,
                Resolution = mergeJob.Resolution,

            };
            output.Add(mediaDto);

            // Set the completion result with the list of merged paths
            mergeJob.CompletionSource.SetResult(output);
        }
        catch (Exception ex)
        {
            // Set the exception in case of an error
            mergeJob.CompletionSource.SetException(ex);
        }
    }


}