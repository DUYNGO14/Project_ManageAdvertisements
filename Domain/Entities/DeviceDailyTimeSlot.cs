namespace Domain.Entities;

public class DeviceDailyTimeSlot
{

    public int DeviceDailyAvailabilityId { get; set; }
    public DeviceDailyAvailability DeviceDailyAvailability { get; set; }

    public int TimeSlotId { get; set; }
    public TimeSlot TimeSlot { get; set; }

    public double TotalAvailableMinutes { get; set; }

}

