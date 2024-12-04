namespace Application.Contents.DTO;

public class MediaDto : CreateMediaDto
{
    public int? Id { get; set; }
    public int? ContentId { get; set; }
}

public class CreateMediaDto
{
    public string FileName { get; set; }

    public string Type { get; set; }

    public string Path { get; set; }

    public int Size { get; set; }

    public int Duration { get; set; }

    public string Resolution { get; set; }
  
}