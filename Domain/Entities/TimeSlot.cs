namespace Domain.Entities;

// Khung thời gian vàng
public class TimeSlot
{
    public int Id { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public bool IsPeak { get; set; } // true là giờ cao điểm 

    public ICollection<ScheduleTimeSlot>? ScheduleSlots { get; set; }
    public ICollection<DeviceDailyTimeSlot> DeviceTimeSlots { get; set; } // Navigation property
}
