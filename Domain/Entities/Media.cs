namespace Domain.Entities;

public class Media
{
    public int Id { get; set; }
    public string FileName { get; set; } = default!;
    //video / imgaes
    public string Type { get; set; } = default!;
    public string Path { get; set; } = default!;
    public int Size { get; set; }
    public int Duration { get; set; }
    public string Resolution { get; set; } = default!;

    public int ContentId { get; set; }
    public Content Content { get; set; } = new();
}
