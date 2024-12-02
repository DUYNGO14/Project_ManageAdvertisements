namespace Domain.Entities;

public class DeviceDailyAvailability
{
    public DateOnly DateTime { get; set; }
    public int DeviceID { get; set; }
    public int TotalAvailableMinutes { get; set; }
    public Device Device { get; set; }
}
