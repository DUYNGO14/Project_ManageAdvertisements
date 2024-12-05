

namespace Application.MasterData.DTO;

public class TimeSlotDto
{
    public int Id { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public string IsPeak { get; set; } // true là giờ cao điểm 

}
