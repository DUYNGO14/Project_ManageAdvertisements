namespace Domain.Entities;

public class DeviceDailyAvailability
{
    public int Id { get; set; }
    public DateOnly DateTime { get; set; }
    public int DeviceID { get; set; }
    public double TotalAvailableMinutes { get; set; }
    public Device Device { get; set; }

    public ICollection<DeviceDailyTimeSlot> DeviceTimeSlots { get; set; } // Navigation property

}
