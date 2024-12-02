namespace Domain.Entities;

public class ScheduleTimeSlot
{
    public int Id { get; set; }
    public int TimeSlotID { get; set; }
    public int ScheduleID { get; set; }

    public TimeSlot TimeSlot { get; set; }
    public Schedule Schedule { get; set; }
}
