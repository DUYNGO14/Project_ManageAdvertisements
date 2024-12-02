namespace Domain.Entities;

public class DeviceType
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Size { get; set; } = default!;
    public string Resolution { get; set; } = default!;
    public ICollection<Device>? Devices { get; set; }

}
