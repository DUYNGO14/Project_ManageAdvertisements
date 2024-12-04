using Application.Common;
using Application.Contents.DTO;
using System.Threading.Channels;

namespace Application.Interfaces;

public class BackgroundServiceQueue : IBackgroundServiceQueue
{
    private readonly Channel<MergeJob> _queue;
    private readonly Dictionary<string, List<string>> _completedMerges = new();
    public BackgroundServiceQueue()
    {
        // Initialize the channel with a bounded capacity
        _queue = Channel.CreateBounded<MergeJob>(new BoundedChannelOptions(100)
        {
            FullMode = BoundedChannelFullMode.Wait,
            SingleReader = true,
            SingleWriter = true,
        });
    }

    public async Task<List<MediaDto>> QueueMergeJob(MergeJob mergeJob)
    {
        // Write the merge job to the channel
        await _queue.Writer.WriteAsync(mergeJob);
        return await mergeJob.CompletionSource.Task;
    }

    public async ValueTask<MergeJob> DequeueAsync(CancellationToken cancellationToken)
    {
        // Read the merge job from the channel
        return await _queue.Reader.ReadAsync(cancellationToken);
    }

    public List<string> GetMergeResult(string fileName)
    {
        return _completedMerges.TryGetValue(fileName, out var outputPaths) ? outputPaths : null;
    }

}
