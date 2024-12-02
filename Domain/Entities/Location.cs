namespace Domain.Entities;

public class Location
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public int Floor { get; set; } 
    public string Department { get; set; } = default!;
    public ICollection<Device>? Devices { get; set; }
}
