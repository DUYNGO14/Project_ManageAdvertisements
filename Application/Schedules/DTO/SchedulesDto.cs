using Application.Devices.DTO;

namespace Application.Schedules.DTO
{
    public class SchedulesDto
    {
        public int Id { get; set; }
        //public ContentDto Contentdto { get; set; }
        public bool IsDefault { get; set; } = false;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DeviceDto Devicedto { get; set; }
    }
}
