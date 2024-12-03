

namespace Application.Common;
public class MergeJob
{
    public string FileName { get; set; } = default!;
    public int TotalChunks { get; set; }
    public string ChunkFolder { get; set; } = default!;
    public string Type { get; set; }
    public string Path { get; set; }
    public int Size { get; set; }
    public int Duration { get; set; }
    public string Resolution { get; set; }
    public List<string> OutputPaths { get; set; } = new List<string>();
    //public TaskCompletionSource<List<MediaDto>> CompletionSource { get; set; } = new TaskCompletionSource<List<MediaDto>>();
}

