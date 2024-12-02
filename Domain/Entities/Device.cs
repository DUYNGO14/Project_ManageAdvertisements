namespace Domain.Entities;

public class Device
{
    public int Id { get; set; }
    public string DeviceName { get; set; } = default!;

    public int LocationId { get; set; }
    public Location? Location { get; set; } 

    public int DeviceTypeId { get; set; }   
    public DeviceType? DeviceType { get; set; }

    //'Active', 'Inactive'
    public string Status { get; set; } = "Active";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;

    public string UserId { get; set; }
    public User User { get; set; }

    public ICollection<DeviceSchedule>? DeviceSchedules { get; set; }
    public ICollection<DeviceDailyAvailability> DeviceDailyAvailabilities { get; set; }
}
