namespace Application.Devices.DTO;

public class DeviceDto
{
    public int Id { get; set; }
    public string? DeviceName { get; set; }
    public string? DeviceType { get; set; }
    public string? Size { get; set; } 
    public string? Resolution { get; set; } 
    public string? Status { get; set; } 
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? Description { get; set; }
    public List<DeScheduleDto>? SchedulesDtos { get; set; } 
    public List<DeviceDailyDto>? DeviceDailyDtos { get; set; }
}




