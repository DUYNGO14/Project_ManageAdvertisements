namespace Application.Devices.DTO;

public class DeviceDailyDto
{
    public DateOnly DateTime { get; set; }
    public double TotalAvailableMinutes { get; set; }  
    public List<DeviceDailyTimeSlotDTO>? DeviceDailyTimeSlots { get; set; }
}

public class DeviceDailyTimeSlotDTO
{
    public string? TimeSlot { get; set; }
    public string? TypeTime {  get; set; }
    public double TotalMinutes { get; set; }
} 