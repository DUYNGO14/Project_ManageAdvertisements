namespace Domain.Entities;

public class Content
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public ICollection<Media> Media { get; set; }
    public bool IsDefault { get; set; } = false;
    //UNUSED or USING
    public string Status { get; set; } = "UNUSED";
    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public ICollection<Schedule>? Schedules { get; set; }
}
