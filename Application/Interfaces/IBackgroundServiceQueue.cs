using Application.Common;
using Application.Contents.DTO;

namespace Application.Interfaces;

public interface IBackgroundServiceQueue
{
    Task<List<MediaDto>> QueueMergeJob(MergeJob mergeJob);
    ValueTask<MergeJob> DequeueAsync(CancellationToken cancellationToken);
    public List<string> GetMergeResult(string fileName);
}
