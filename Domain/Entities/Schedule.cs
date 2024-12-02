namespace Domain.Entities;

public class Schedule
{
    public int Id { get; set; }
    public int DeviceID { get; set; }
    public int ContentID { get; set; }
    public DateTime StartDate { get; set; } // Ngày bắt đầu
    public DateTime EndDate { get; set; } // Ngày kết thúc
    public int Frequency { get; set; } // Số lần phát trong khung giờ 
    public int TotalDuration { get; set; } // Tổng thời gian phát (giây) = Frequency * Media.Duration
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public ICollection<ScheduleTimeSlot> ScheduleSlots { get; set; }
    public ICollection<DeviceSchedule>? DeviceSchedules { get; set; }
    public Content Content { get; set; }
}
