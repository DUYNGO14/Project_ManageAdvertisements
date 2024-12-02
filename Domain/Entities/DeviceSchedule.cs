namespace Domain.Entities
{
    public class DeviceSchedule
    {
        public int Id { get; set; }
        public int DeviceID { get; set; }
        public int ScheduleID { get; set; }

        public Device Device { get; set; }
        public Schedule Schedule { get; set; }
    }
}
